using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
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
    //[Authorize]
    public class SchoolMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();
        IQueryable<SchoolMaster> schools;


        //[Route("webapi/SchoolMasters/{countryId}/{stateId}/{cityId}")]
        // GET: api/SchoolMasters
        public IQueryable<SchoolMasterViewModel> GetSchools()
        {
            var schools = from b in db.Schools
                          join s in db.States on b.StateId equals s.Id
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
                              StateName = s.Name,
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

        // GET: api/SchoolMasters/5
        //[ResponseType(typeof(SchoolMasterViewModel))]
        //public IHttpActionResult GetSchoolMaster()
        //{
        //    var schools = from b in db.Schools
        //                  join s in db.States on b.StateId equals s.Id
        //                  orderby b.SchoolName
        //                  select new SchoolMasterViewModel()
        //                  {
        //                      Id = b.Id,
        //                      Name = b.SchoolName,
        //                      HouseNumber = b.HouseNumber,
        //                      Street = b.Street,
        //                      Area = b.Area,
        //                      LGA = b.LGA,
        //                      LandMark = b.LandMark,
        //                      StateId = b.StateId,
        //                      StateName = s.StateName,
        //                      GeoCoordinate = b.GeoCoordinate,
        //                      PrincipalName = b.PrincipalName,
        //                      PhoneNumber = b.PhoneNumber,
        //                      SchoolPhoneNumber = b.SchoolPhoneNumber,
        //                      SchoolType = b.SchoolType,
        //                      TotalPopulation = b.TotalPopulation,
        //                      TotalEducationlevel = b.TotalEducationlevel,
        //                      NursaryToPrimary3Population = b.NursaryToPrimary3Population,
        //                  };
        //    return Ok(schools);
        //}

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
            catch (Exception ex)
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

        // POST: api/SchoolMasters
        [ResponseType(typeof(SchoolMasterViewModel))]
        public async Task<IHttpActionResult> PostSchoolMaster(SchoolMasterViewModel schoolMasterViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var school = from state in db.States
                         join branch in db.Branches on state.BranchId equals branch.Id
                         join zone in db.Zones on branch.ZoneId equals zone.Id
                         join country in db.Countries on zone.CountryId equals country.Id
                         where state.Id == schoolMasterViewModel.StateId
                         select new SchoolMasterViewModel
                         {
                             CountryId = country.Id,
                             ZoneId = zone.Id,
                             BranchId = branch.Id,
                             StateId = schoolMasterViewModel.StateId,
                             SchoolType = schoolMasterViewModel.SchoolType,
                             SchoolName = schoolMasterViewModel.SchoolName,
                             HouseNumber = schoolMasterViewModel.HouseNumber,
                             Street = schoolMasterViewModel.Street,
                             Area = schoolMasterViewModel.Area,
                             LGA = schoolMasterViewModel.LGA,
                             LandMark = schoolMasterViewModel.LandMark,
                             GeoCoordinate = schoolMasterViewModel.GeoCoordinate,
                             PrincipalName = schoolMasterViewModel.PrincipalName,
                             PhoneNumber = schoolMasterViewModel.PhoneNumber,
                             SchoolPhoneNumber = schoolMasterViewModel.SchoolPhoneNumber,
                             TotalPopulation = schoolMasterViewModel.TotalPopulation,
                             TotalEducationlevel = schoolMasterViewModel.TotalEducationlevel,
                             NursaryToPrimary3Population = schoolMasterViewModel.NursaryToPrimary3Population,
                             Approved = schoolMasterViewModel.Approved,
                             Source = schoolMasterViewModel.Source,
                             Status = schoolMasterViewModel.Status
                         };
            var schoolModel = school.FirstOrDefault();
            SchoolMaster schoolMaster = new SchoolMaster();
            schoolMaster.Id = schoolMasterViewModel.Id;
            schoolMaster.CountryId = schoolMasterViewModel.CountryId;
            schoolMaster.ZoneId = schoolMasterViewModel.ZoneId;
            schoolMaster.BranchId = schoolMasterViewModel.BranchId;
            schoolMaster.StateId = schoolMasterViewModel.StateId;
            schoolMaster.SchoolType = schoolMasterViewModel.SchoolType;
            schoolMaster.SchoolName = schoolMasterViewModel.SchoolName;
            schoolMaster.HouseNumber = schoolMasterViewModel.HouseNumber;
            schoolMaster.Street = schoolMasterViewModel.Street;
            schoolMaster.Area = schoolMasterViewModel.Area;
            schoolMaster.LGA = schoolMasterViewModel.LGA;
            schoolMaster.LandMark = schoolMasterViewModel.LandMark;
            schoolMaster.GeoCoordinate = schoolMasterViewModel.GeoCoordinate;
            schoolMaster.PrincipalName = schoolMasterViewModel.PrincipalName;
            schoolMaster.PhoneNumber = schoolMasterViewModel.PhoneNumber;
            schoolMaster.SchoolPhoneNumber = schoolMasterViewModel.SchoolPhoneNumber;
            schoolMaster.TotalPopulation = schoolMasterViewModel.TotalPopulation;
            schoolMaster.TotalEducationlevel = schoolMasterViewModel.TotalEducationlevel;
            schoolMaster.NursaryToPrimary3Population = schoolMasterViewModel.NursaryToPrimary3Population;
            schoolMaster.Approved = schoolMasterViewModel.Approved;
            schoolMaster.Source = schoolMasterViewModel.Source;
            schoolMaster.Status = schoolMasterViewModel.Status;
            schoolMaster.Created = DateTime.Now;
            schoolMaster.Updated = DateTime.Now;
            if (schoolMaster.Id > 0)
            {
                return PutSchoolMaster(schoolMaster);
            }
            try
            {
                db.Schools.Add(schoolMaster);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return CreatedAtRoute("DefaultApi", new { id = schoolMaster.Id }, schoolMaster);
        }

        // DELETE: api/SchoolMasters/5
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