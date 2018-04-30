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
    public class StateMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/StateMasters
        public IQueryable<StateMasterViewModel> GetStates()
        {
            var states = from s in db.States
                         select new StateMasterViewModel()
                         {
                             Id = s.Id,
                             Name = s.StateName
                         };
            return states;
        }

        // GET: api/StateMasters/5
        [ResponseType(typeof(StateMasterViewModel))]
        public IHttpActionResult GetStateMaster(int branchId)
        {
            var stateMaster = from b in db.States
                              join br in db.Branches on b.BranchId equals br.Id
                              where b.BranchId == branchId
                              select new StateMasterViewModel()
                              {
                                  Id = b.Id,
                                  Name = b.StateName,
                                  BranchId = b.BranchId,
                                  BranchName = br.BranchName
                              };

            if (stateMaster == null)
            {
                return NotFound();
            }

            return Ok(stateMaster);
        }

        // PUT: api/StateMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStateMaster(int id, StateMaster stateMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stateMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(stateMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateMasterExists(id))
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

        // POST: api/StateMasters
        [ResponseType(typeof(StateMaster))]
        public async Task<IHttpActionResult> PostStateMaster(StateMaster stateMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.States.Add(stateMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stateMaster.Id }, stateMaster);
        }

        // DELETE: api/StateMasters/5
        [ResponseType(typeof(StateMaster))]
        public async Task<IHttpActionResult> DeleteStateMaster(int id)
        {
            StateMaster stateMaster = await db.States.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            db.States.Remove(stateMaster);
            await db.SaveChangesAsync();

            return Ok(stateMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateMasterExists(int id)
        {
            return db.States.Count(e => e.Id == id) > 0;
        }
    }
}