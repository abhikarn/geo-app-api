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
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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

        // PUT: api/SchoolMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSchoolMaster(int id, SchoolMaster schoolMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schoolMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(schoolMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolMasterExists(id))
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