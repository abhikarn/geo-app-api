﻿using System;
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
    [Authorize]
    public class SchoolMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();


        //[Route("webapi/SchoolMasters/{countryId}/{stateId}/{cityId}")]
        // GET: api/SchoolMasters
        public IQueryable<SchoolMaster> GetSchools(int countryId, int stateId, int cityId)
        {
            IQueryable<SchoolMaster> schools;
            //var schools = from b in db.Schools
            //              select new SchoolMasterViewModel()
            //              {
            //                  Id = b.Id,
            //                  SchoolName = b.SchoolName,
            //                  HouseNumber = b.HouseNumber,
            //                  Streat = b.Streat,
            //                  Area = b.Area,
            //                  LGA = b.LGA,
            //                  LandMark = b.LandMark
            //              };

            //return schools;
            schools = db.Schools;
            if (countryId > 0)
                schools = schools.Where(x => x.CountryId == countryId);
            if (stateId > 0)
                schools = schools.Where(x => x.StateId == stateId);
            //if (cityId > 0)
            //    schools = schools.Where(x => x.CityId == cityId);
            return schools;
        }

        // GET: api/SchoolMasters/5
        [ResponseType(typeof(SchoolMaster))]
        public IHttpActionResult GetSchoolMaster()
        {
            return Ok(db.Schools);
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

        // POST: api/SchoolMasters
        [ResponseType(typeof(SchoolMaster))]
        public async Task<IHttpActionResult> PostSchoolMaster(SchoolMaster schoolMaster)
        {
            schoolMaster.Created = DateTime.Now;
            schoolMaster.Updated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            schoolMaster.CountryId = schoolModel.CountryId;
            schoolMaster.ZoneId = schoolModel.ZoneId;
            schoolMaster.BranchId = schoolModel.BranchId;

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