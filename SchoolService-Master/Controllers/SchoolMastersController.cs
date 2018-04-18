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
    public class SchoolMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/SchoolMasters
        public IQueryable<SchoolMaster> GetSchools()
        {
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
            return db.Schools;
        }

        // GET: api/SchoolMasters/5
        [ResponseType(typeof(SchoolMaster))]
        public async Task<IHttpActionResult> GetSchoolMaster(int id)
        {
            SchoolMaster schoolMaster = await db.Schools.FindAsync(id);
            if (schoolMaster == null)
            {
                return NotFound();
            }

            return Ok(schoolMaster);
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
                throw;
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