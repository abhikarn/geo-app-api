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
    public class UsersController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();

        // GET: api/Users
        public IQueryable<UserViewModel> GetUsers()
        {
            var users = from user in db.Users
                        join role in db.Roles on user.RoleId equals role.Id
                        join country in db.Countries on user.CountryId equals country.Id
                        join state in db.States on user.StateId equals state.Id
                        join city in db.City on user.CityId equals city.Id
                        select new UserViewModel
                        {
                            UserMasterId = user.Id,
                            UserName = user.UserName,
                            EmailId = user.EmailId,
                            UserPassword = user.UserPassword,
                            IsActive = user.IsActive,
                            LastLoginDate = user.LastLoginDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RoleId = user.RoleId,
                            RoleName = role.Name,
                            Status = user.Status,
                            CountryId = user.CountryId,
                            CountryName = country.CountryrName,
                            StateId = user.StateId,
                            StateName = state.StateName,
                            CityId = user.CityId,
                            CityName = city.CityName
                        };
            return users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> GetUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        public IHttpActionResult PutUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(users.Id))
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

        // POST: api/Users
        [ResponseType(typeof(UserViewModel))]
        public async Task<IHttpActionResult> PostUsers(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Users user = userViewModel;
            if (userViewModel.UserMasterId > 0)
            {
                return PutUsers(user);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> DeleteUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            await db.SaveChangesAsync();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}