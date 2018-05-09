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
    public class SupervisorMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/SupervisorMasters
        public IQueryable<SupervisorMasterViewModel> GetSupervisors()
        {
            var supervisors = from b in db.Supervisors
                              select new SupervisorMasterViewModel()
                              {
                                  Id = b.Id,
                                  Name = b.Name
                              };

            return supervisors;
        }

        // GET: api/SupervisorMasters/5
        [ResponseType(typeof(SupervisorMaster))]
        public async Task<IHttpActionResult> GetSupervisorMaster(int id)
        {
            SupervisorMaster supervisorMaster = await db.Supervisors.FindAsync(id);
            if (supervisorMaster == null)
            {
                return NotFound();
            }

            return Ok(supervisorMaster);
        }

        // PUT: api/SupervisorMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSupervisorMaster(int id, SupervisorMaster supervisorMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supervisorMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(supervisorMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisorMasterExists(id))
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

        // POST: api/SupervisorMasters
        [ResponseType(typeof(SupervisorMaster))]
        public async Task<IHttpActionResult> PostSupervisorMaster(SupervisorMaster supervisorMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supervisors.Add(supervisorMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = supervisorMaster.Id }, supervisorMaster);
        }

        // DELETE: api/SupervisorMasters/5
        [ResponseType(typeof(SupervisorMaster))]
        public async Task<IHttpActionResult> DeleteSupervisorMaster(int id)
        {
            SupervisorMaster supervisorMaster = await db.Supervisors.FindAsync(id);
            if (supervisorMaster == null)
            {
                return NotFound();
            }

            db.Supervisors.Remove(supervisorMaster);
            await db.SaveChangesAsync();

            return Ok(supervisorMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupervisorMasterExists(int id)
        {
            return db.Supervisors.Count(e => e.Id == id) > 0;
        }
    }
}