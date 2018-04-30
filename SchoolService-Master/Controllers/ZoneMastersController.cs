using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    public class ZoneMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/ZoneMasters
        public IQueryable<ZoneMasterViewModel> GetZones(int countryId)
        {
            var zones = from b in db.Zones
                        join c in db.Countries on b.CountryId equals c.Id
                        where c.Id == countryId
                        select new ZoneMasterViewModel()
                        {
                            Id = b.Id,
                            Name = b.ZoneName,
                            CountryId = b.CountryId,
                            CountryName = c.CountryrName
                        };

            return zones;
        }

        // GET: api/ZoneMasters/5
        [ResponseType(typeof(ZoneMaster))]
        public async Task<IHttpActionResult> GetZoneMaster(int id)
        {
            ZoneMaster zoneMaster = await db.Zones.FindAsync(id);
            if (zoneMaster == null)
            {
                return NotFound();
            }

            return Ok(zoneMaster);
        }

        // PUT: api/ZoneMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZoneMaster(int id, ZoneMaster zoneMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zoneMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(zoneMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ZoneMasters
        [ResponseType(typeof(ZoneMaster))]
        public async Task<IHttpActionResult> PostZoneMaster(ZoneMaster zoneMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zones.Add(zoneMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zoneMaster.Id }, zoneMaster);
        }

        // DELETE: api/ZoneMasters/5
        [ResponseType(typeof(ZoneMaster))]
        public async Task<IHttpActionResult> DeleteZoneMaster(int id)
        {
            ZoneMaster zoneMaster = await db.Zones.FindAsync(id);
            if (zoneMaster == null)
            {
                return NotFound();
            }

            db.Zones.Remove(zoneMaster);
            await db.SaveChangesAsync();

            return Ok(zoneMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneMasterExists(int id)
        {
            return db.Zones.Count(e => e.Id == id) > 0;
        }
    }
}