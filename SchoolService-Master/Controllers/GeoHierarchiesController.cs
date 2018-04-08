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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    [EnableCors(origins: "http://localhost:7070", headers: "*", methods: "*")]
    public class GeoHierarchiesController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/GeoHierarchies
        public IQueryable<GeoHierarchy> GetGeoHierarchies()
        {
            return db.GeoHierarchies;
        }

        // GET: api/GeoHierarchies/5
        [ResponseType(typeof(GeoHierarchy))]
        public async Task<IHttpActionResult> GetGeoHierarchy(int id)
        {
            GeoHierarchy geoHierarchy = await db.GeoHierarchies.FindAsync(id);
            if (geoHierarchy == null)
            {
                return NotFound();
            }

            return Ok(geoHierarchy);
        }

        // PUT: api/GeoHierarchies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGeoHierarchy(int id, GeoHierarchy geoHierarchy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != geoHierarchy.id)
            {
                return BadRequest();
            }

            db.Entry(geoHierarchy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoHierarchyExists(id))
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

        // POST: api/GeoHierarchies
        [ResponseType(typeof(GeoHierarchy))]
        public async Task<IHttpActionResult> PostGeoHierarchy(GeoHierarchyViewModel geoHierarchy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.GeoHierarchies.Add(new GeoHierarchy
                    {
                        countryId = geoHierarchy.CountryId,
                        zoneId = geoHierarchy.ZoneId,
                        branchId = geoHierarchy.BranchId,
                        stateId = geoHierarchy.StateId,
                        supervisorId = geoHierarchy.SupervisorId,
                        marketingHierarchyUser = geoHierarchy.MarketingHierarchyUser,
                        created = DateTime.Now,
                        updated = DateTime.Now
                    });
                    await db.SaveChangesAsync();
                    List<SchoolGeoHierarchyMapping> schoolGeoHierarchyMapping = new List<SchoolGeoHierarchyMapping>();
                    foreach (SchoolGeoHierarchyMappingViewModel item in geoHierarchy.SchoolGeoHierarchyMappingViewModels)
                    {
                        schoolGeoHierarchyMapping.Add(new SchoolGeoHierarchyMapping { SchoolId = item.id, GeoHierarchyId = geoHierarchy.Id });
                    }
                    db.SchoolGeoHierarchyMapping.AddRange(schoolGeoHierarchyMapping);
                    await db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }

            return CreatedAtRoute("DefaultApi", new { id = geoHierarchy.Id }, geoHierarchy);
        }

        // DELETE: api/GeoHierarchies/5
        [ResponseType(typeof(GeoHierarchy))]
        public async Task<IHttpActionResult> DeleteGeoHierarchy(int id)
        {
            GeoHierarchy geoHierarchy = await db.GeoHierarchies.FindAsync(id);
            if (geoHierarchy == null)
            {
                return NotFound();
            }

            db.GeoHierarchies.Remove(geoHierarchy);
            await db.SaveChangesAsync();

            return Ok(geoHierarchy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeoHierarchyExists(int id)
        {
            return db.GeoHierarchies.Count(e => e.id == id) > 0;
        }
    }
}