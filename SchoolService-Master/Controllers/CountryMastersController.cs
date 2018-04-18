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
    public class CountryMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/CountryMasters
        public IQueryable<CountryMasterViewModel> GetCountries()
        {
            var countries = from b in db.Countries
                            select new CountryMasterViewModel()
                          {
                              Id = b.Id,
                              Name=b.CountryrName
                          };

            return countries;
        }

        // GET: api/CountryMasters/5
        [ResponseType(typeof(CountryMaster))]
        public async Task<IHttpActionResult> GetCountryMaster(int id)
        {
            CountryMaster countryMaster = await db.Countries.FindAsync(id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            return Ok(countryMaster);
        }

        // PUT: api/CountryMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCountryMaster(int id, CountryMaster countryMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(countryMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryMasterExists(id))
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

        // POST: api/CountryMasters
        [ResponseType(typeof(CountryMaster))]
        public async Task<IHttpActionResult> PostCountryMaster(CountryMaster countryMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(countryMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = countryMaster.Id }, countryMaster);
        }

        // DELETE: api/CountryMasters/5
        [ResponseType(typeof(CountryMaster))]
        public async Task<IHttpActionResult> DeleteCountryMaster(int id)
        {
            CountryMaster countryMaster = await db.Countries.FindAsync(id);
            if (countryMaster == null)
            {
                return NotFound();
            }

            db.Countries.Remove(countryMaster);
            await db.SaveChangesAsync();

            return Ok(countryMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryMasterExists(int id)
        {
            return db.Countries.Count(e => e.Id == id) > 0;
        }
    }
}