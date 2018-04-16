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
        [ResponseType(typeof(GeoHierarchyViewModel))]
        public async Task<IHttpActionResult> GetGeoHierarchy(int id)
        {
            GeoHierarchyViewModel geoHierarchy = await db.GeoHierarchies.FindAsync(id);
            if (geoHierarchy == null)
            {
                return NotFound();
            }
            List<SchoolGeoHierarchyMapping> schoolGeoHierarchyMapping = await db.SchoolGeoHierarchyMapping
                                                                                .Where(x => x.GeoHierarchyId == id).ToListAsync();
            geoHierarchy.SchoolGeoHierarchyMappingViewModels = schoolGeoHierarchyMapping
                                                                .Select<SchoolGeoHierarchyMapping, SchoolGeoHierarchyMappingViewModel>(x => x).ToList();


            return Ok(geoHierarchy);
        }

        public IHttpActionResult PutGeoHierarchy(int id, GeoHierarchyViewModel geoHierarchyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != geoHierarchyViewModel.Id)
            {
                return BadRequest();
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    GeoHierarchy geoHierarchy = geoHierarchyViewModel;
                    db.Entry(geoHierarchy).State = EntityState.Modified;
                    db.SaveChanges();
                    List<SchoolGeoHierarchyMapping> lstSchoolGeoHierarchyMapping = db.SchoolGeoHierarchyMapping.Where(a => a.GeoHierarchyId == geoHierarchyViewModel.Id).ToList();
                    db.SchoolGeoHierarchyMapping.RemoveRange(lstSchoolGeoHierarchyMapping);
                    db.SaveChanges();
                    lstSchoolGeoHierarchyMapping.Clear();
                    foreach (SchoolGeoHierarchyMappingViewModel item in geoHierarchyViewModel.SchoolGeoHierarchyMappingViewModels)
                    {
                        lstSchoolGeoHierarchyMapping.Add(new SchoolGeoHierarchyMapping { SchoolId = item.Id, GeoHierarchyId = geoHierarchyViewModel.Id });
                    }
                    db.SchoolGeoHierarchyMapping.AddRange(lstSchoolGeoHierarchyMapping);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    transaction.Rollback();
                    if (!GeoHierarchyExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GeoHierarchies
        [ResponseType(typeof(GeoHierarchy))]
        public async Task<IHttpActionResult> PostGeoHierarchy(GeoHierarchyViewModel geoHierarchyViewModel, int id = 0)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id > 0)
            {
                return PutGeoHierarchy(id, geoHierarchyViewModel);
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    GeoHierarchy geoHierarchy = geoHierarchyViewModel;
                    db.GeoHierarchies.Add(geoHierarchy);
                    await db.SaveChangesAsync();
                    List<SchoolGeoHierarchyMapping> lstSchoolGeoHierarchyMapping = new List<SchoolGeoHierarchyMapping>();
                    foreach (SchoolGeoHierarchyMappingViewModel item in geoHierarchyViewModel.SchoolGeoHierarchyMappingViewModels)
                    {
                        lstSchoolGeoHierarchyMapping.Add(new SchoolGeoHierarchyMapping { SchoolId = item.Id, GeoHierarchyId = geoHierarchy.Id });
                    }
                    db.SchoolGeoHierarchyMapping.AddRange(lstSchoolGeoHierarchyMapping);
                    await db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }

            return CreatedAtRoute("DefaultApi", new { id = geoHierarchyViewModel.Id }, geoHierarchyViewModel);
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