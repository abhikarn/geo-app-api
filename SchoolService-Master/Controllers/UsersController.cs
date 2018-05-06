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
using SchoolService_Master.Provider;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    [ClientIdAuthorizationProvider]
    [Authorize]
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
                        //join city in db.City on user.CityId equals city.Id
                        orderby user.UserName
                        select new UserViewModel
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            EmailId = user.EmailId,
                            UserPassword = user.UserPassword,
                            IsActive = user.IsActive,
                            LastLoginDate = user.LastLoginDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Name = user.FirstName + " " + user.LastName,
                            RoleId = user.RoleId,
                            RoleName = role.Name,
                            Status = user.Status,
                            CountryId = user.CountryId,
                            CountryName = country.CountryrName,
                            StateId = user.StateId,
                            StateName = state.StateName,
                            //CityId = user.CityId,
                            //CityName = city.CityName
                        };
            return users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult GetRoleBasedUser(int countryId, int stateId, string role)
        {
            var users = from user in db.Users
                        join roles in db.Roles on user.RoleId equals roles.Id
                        join country in db.Countries on user.CountryId equals country.Id
                        join state in db.States on user.StateId equals state.Id
                        where roles.Name == role
                        orderby user.UserName
                        select new UserViewModel
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            EmailId = user.EmailId,
                            UserPassword = user.UserPassword,
                            IsActive = user.IsActive,
                            LastLoginDate = user.LastLoginDate,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Name = user.FirstName + " " + user.LastName,
                            RoleId = user.RoleId,
                            RoleName = roles.Name,
                            Status = user.Status,
                            CountryId = user.CountryId,
                            CountryName = country.CountryrName,
                            StateId = user.StateId,
                            StateName = state.StateName
                        };
            if (countryId > 0)
                users = users.Where(x => x.CountryId == countryId);
            if (stateId > 0)
                users = users.Where(x => x.StateId == stateId);
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

            var users = from state in db.States
                        join branch in db.Branches on state.BranchId equals branch.Id
                        join zone in db.Zones on branch.ZoneId equals zone.Id
                        join country in db.Countries on zone.CountryId equals country.Id
                        where state.Id == userViewModel.StateId
                        select new UserViewModel
                        {
                            Id = userViewModel.Id,
                            UserName = userViewModel.UserName,
                            EmailId = userViewModel.EmailId,
                            UserPassword = userViewModel.UserPassword,
                            IsActive = userViewModel.IsActive,
                            LastLoginDate = userViewModel.LastLoginDate,
                            FirstName = userViewModel.FirstName,
                            LastName = userViewModel.LastName,
                            RoleId = userViewModel.RoleId,
                            Status = userViewModel.Status,
                            CountryId = country.Id,
                            ZoneId = zone.Id,
                            BranchId = branch.Id,
                            StateId = userViewModel.StateId
                        };
            UserViewModel userModel = users.FirstOrDefault();
            Users user = new Users
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                EmailId = userModel.EmailId,
                UserPassword = userModel.UserPassword,
                IsActive = userModel.IsActive,
                LastLoginDate = userModel.LastLoginDate,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                RoleId = userModel.RoleId,
                Status = userModel.Status,
                CountryId = userModel.CountryId,
                ZoneId = userModel.ZoneId,
                BranchId = userModel.BranchId,
                StateId = userViewModel.StateId
            };
            if (userViewModel.Id > 0)
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