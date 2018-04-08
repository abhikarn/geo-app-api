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
        public IQueryable<GeoHierarchyViewModel> GetGeoHierarchies()
        {
            var geohierarchies = from GH in db.GeoHierarchies
                                 join COU in db.Countries on GH.CountryId equals COU.Id
                                 join STA in db.States on GH.StateId equals STA.Id
                                 join ZON in db.Zones on GH.ZoneId equals ZON.Id
                                 join BRA in db.Branches on GH.BranchId equals BRA.Id
                                 join SUP in db.Supervisors on GH.SupervisorId equals SUP.Id
                                 select new GeoHierarchyViewModel
                                 {
                                     CountryName = COU.CountryrName,
                                     StateName = STA.StateName,
                                     ZoneName = ZON.ZoneName,
                                     BranchName = BRA.BranchName,
                                     SupervisorName = SUP.SupervisorName,
                                     MarketingHierarchyUser = GH.MarketingHierarchyUser,
                                 };
            return geohierarchies;
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

            if (id != geoHierarchy.Id)
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
                        CountryId = geoHierarchy.CountryId,
                        ZoneId = geoHierarchy.ZoneId,
                        BranchId = geoHierarchy.BranchId,
                        StateId = geoHierarchy.StateId,
                        SupervisorId = geoHierarchy.SupervisorId,
                        MarketingHierarchyUser = geoHierarchy.MarketingHierarchyUser,
                        Created = DateTime.Now,
                        Updated = DateTime.Now
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
            return db.GeoHierarchies.Count(e => e.Id == id) > 0;
        }
    }
}