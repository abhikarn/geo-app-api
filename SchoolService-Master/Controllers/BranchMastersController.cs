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
    public class BranchMastersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/BranchMasters
        public IQueryable<BranchMasterViewModel> GetBranches()
        {
            var branches = from b in db.Branches
                         select new BranchMasterViewModel()
                         {
                             Id = b.Id,
                             BranchName = b.BranchName
                         };

            return branches;
        }

        // GET: api/BranchMasters/5
        [ResponseType(typeof(BranchMaster))]
        public async Task<IHttpActionResult> GetBranchMaster(int id)
        {
            BranchMaster branchMaster = await db.Branches.FindAsync(id);
            if (branchMaster == null)
            {
                return NotFound();
            }

            return Ok(branchMaster);
        }

        // PUT: api/BranchMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBranchMaster(int id, BranchMaster branchMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(branchMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchMasterExists(id))
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

        // POST: api/BranchMasters
        [ResponseType(typeof(BranchMaster))]
        public async Task<IHttpActionResult> PostBranchMaster(BranchMaster branchMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Branches.Add(branchMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = branchMaster.Id }, branchMaster);
        }

        // DELETE: api/BranchMasters/5
        [ResponseType(typeof(BranchMaster))]
        public async Task<IHttpActionResult> DeleteBranchMaster(int id)
        {
            BranchMaster branchMaster = await db.Branches.FindAsync(id);
            if (branchMaster == null)
            {
                return NotFound();
            }

            db.Branches.Remove(branchMaster);
            await db.SaveChangesAsync();

            return Ok(branchMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchMasterExists(int id)
        {
            return db.Branches.Count(e => e.Id == id) > 0;
        }
    }
}