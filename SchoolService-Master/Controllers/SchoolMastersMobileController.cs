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
using SchoolService_Master.Provider;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    [ClientIdAuthorizationProvider]
    public class SchoolMastersMobileController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();


        //[Route("webapi/SchoolMastersMobile/{countryId}/{stateId}/{cityId}")]
        // GET: api/SchoolMastersMobile
        public IQueryable<SchoolMasterViewModel> GetSchools()
        {
            var schools = from b in db.Schools
                              //join s in db.States on b.StateId equals s.Id
                              //where b.StateId == stateId
                          orderby b.SchoolName
                          select new SchoolMasterViewModel()
                          {
                              Id = b.Id,
                              SchoolName = b.SchoolName,
                              HouseNumber = b.HouseNumber,
                              Street = b.Street,
                              Area = b.Area,
                              LGA = b.LGA,
                              LandMark = b.LandMark,
                              StateId = b.StateId,
                              //StateName = s.Name,
                              GeoCoordinate = b.GeoCoordinate,
                              PrincipalName = b.PrincipalName,
                              PhoneNumber = b.PhoneNumber,
                              SchoolPhoneNumber = b.SchoolPhoneNumber,
                              SchoolType = b.SchoolType,
                              TotalPopulation = b.TotalPopulation,
                              TotalEducationlevel = b.TotalEducationlevel,
                              NursaryToPrimary3Population = b.NursaryToPrimary3Population,
                              Approved = b.Approved,
                              Source = b.Source,
                              Status = b.Status
                          };

            return schools;
        }

        public IHttpActionResult PutSchoolMaster(SchoolMaster schoolMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(schoolMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolMasterExists(schoolMaster.Id))
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

        // POST: api/SchoolMastersMobile
        [ResponseType(typeof(SchoolMaster))]
        public async Task<IHttpActionResult> PostSchoolMaster(SchoolMaster[] schoolMasters)
        {
            List<SchoolMaster> schoolMasterLst = new List<SchoolMaster>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (SchoolMaster schoolMaster in schoolMasters)
            {
                schoolMaster.Created = DateTime.Now;
                schoolMaster.Updated = DateTime.Now;
                var school = from state in db.States
                             join branch in db.Branches on state.BranchId equals branch.Id
                             join zone in db.Zones on branch.ZoneId equals zone.Id
                             join country in db.Countries on zone.CountryId equals country.Id
                             where state.Id == schoolMaster.StateId
                             select new SchoolMasterViewModel
                             {
                                 CountryId = country.Id,
                                 ZoneId = zone.Id,
                                 BranchId = branch.Id,
                                 StateId = schoolMaster.StateId
                             };
                var schoolModel = school.FirstOrDefault();
                if (schoolModel != null)
                {
                    schoolMaster.CountryId = schoolModel.CountryId;
                    schoolMaster.ZoneId = schoolModel.ZoneId;
                    schoolMaster.BranchId = schoolModel.BranchId;
                }
                if (schoolMaster.Id > 0)
                {
                    return PutSchoolMaster(schoolMaster);
                }
                try
                {
                    db.Schools.Add(schoolMaster);
                    await db.SaveChangesAsync();
                    schoolMasterLst.Add(schoolMaster);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Ok(schoolMasterLst);
            //return CreatedAtRoute("DefaultApi", new { id = schoolMaster.Id }, schoolMaster);
        }

        // POST: api/SchoolMastersMobile
        [ResponseType(typeof(SchoolMaster))]
        public async Task<IHttpActionResult> PatchSchoolMaster(SchoolMaster[] schoolMasters)
        {
            List<SchoolMaster> schoolMasterLst = new List<SchoolMaster>();

            foreach (SchoolMaster schoolMaster in schoolMasters)
            {
                var schoolMasterModel = db.Schools.SingleOrDefault(p => p.Id == schoolMaster.Id);
                if (schoolMasterModel != null)
                {
                    schoolMasterModel.Updated = DateTime.Now;
                    schoolMasterModel.SchoolImage = schoolMaster.SchoolImage;
                }

                try
                {
                    db.Entry(schoolMaster).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
            }

            return Ok(schoolMasterLst);
            //return CreatedAtRoute("DefaultApi", new { id = schoolMaster.Id }, schoolMaster);
        }

        // DELETE: api/SchoolMastersMobile/5
        [ResponseType(typeof(SchoolMaster))]
        public async Task<IHttpActionResult> DeleteSchoolMaster(int id)
        {
            SchoolMaster schoolMaster = await db.Schools.FindAsync(id);
            if (schoolMaster == null)
            {
                return NotFound();
            }

            db.Schools.Remove(schoolMaster);
            await db.SaveChangesAsync();

            return Ok(schoolMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolMasterExists(int id)
        {
            return db.Schools.Count(e => e.Id == id) > 0;
        }
    }
}