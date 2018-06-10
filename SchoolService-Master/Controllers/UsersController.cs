using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SchoolService_Master.Common;
using SchoolService_Master.Models;
using SchoolService_Master.Provider;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    //[ClientIdAuthorizationProvider]
    //[Authorize]
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
                            //UserPassword = user.UserPassword,
                            IsActive = user.IsActive,
                            LastLoginDate = user.LastLoginDate,
                            DateOfBirth = SqlFunctions.DateName("month", user.DateOfBirth) + "/" + SqlFunctions.DateName("day", user.DateOfBirth) + "/" + SqlFunctions.DateName("year", user.DateOfBirth),
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Name = user.FirstName + " " + user.LastName,
                            RoleId = user.RoleId,
                            RoleName = role.Name,
                            Status = user.Status,
                            CountryId = user.CountryId,
                            CountryName = country.Name,
                            StateId = user.StateId,
                            StateName = state.Name,
                            NotFirstLogin = user.NotFirstLogin
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
                            //UserPassword = user.UserPassword,
                            IsActive = user.IsActive,
                            LastLoginDate = user.LastLoginDate,
                            DateOfBirth = SqlFunctions.DateName("month", user.DateOfBirth) + "/" + SqlFunctions.DateName("day", user.DateOfBirth) + "/" + SqlFunctions.DateName("year", user.DateOfBirth),
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Name = user.FirstName + " " + user.LastName,
                            RoleId = user.RoleId,
                            RoleName = roles.Name,
                            Status = user.Status,
                            CountryId = user.CountryId,
                            CountryName = country.Name,
                            StateId = user.StateId,
                            StateName = state.Name,
                            NotFirstLogin = user.NotFirstLogin
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
                            DateOfBirth = userViewModel.DateOfBirth,//SqlFunctions.DateName("month", userViewModel.DateOfBirth) + "/" + SqlFunctions.DateName("day", userViewModel.DateOfBirth) + "/" + SqlFunctions.DateName("year", userViewModel.DateOfBirth),
                            FirstName = userViewModel.FirstName,
                            LastName = userViewModel.LastName,
                            RoleId = userViewModel.RoleId,
                            Status = userViewModel.Status,
                            CountryId = country.Id,
                            ZoneId = zone.Id,
                            BranchId = branch.Id,
                            StateId = userViewModel.StateId,
                            NotFirstLogin = userViewModel.NotFirstLogin
                        };
            UserViewModel userModel = users.FirstOrDefault();
            if (userModel == null)
            {
                return BadRequest();
            }
            userModel.UserPassword = string.Concat(userModel.FirstName.Substring(0, 2), userModel.DateOfBirth.Substring(0, 2));
            Users user = new Users
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                EmailId = userModel.EmailId,
                UserPassword = userModel.UserPassword,
                IsActive = userModel.IsActive,
                LastLoginDate = userModel.LastLoginDate,
                DateOfBirth = Convert.ToDateTime(userModel.DateOfBirth),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                RoleId = userModel.RoleId,
                Status = userModel.Status,
                CountryId = userModel.CountryId,
                ZoneId = userModel.ZoneId,
                BranchId = userModel.BranchId,
                StateId = userViewModel.StateId,
                NotFirstLogin = userViewModel.NotFirstLogin
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

        // GET: webapi/Token comment
        [HttpPatch]
        [ResponseType(typeof(UserViewModel))]
        [Route("webapi/ResetPassword")]
        public IHttpActionResult ResetPassword(ResetViewModel resetModel)
        {
            Users user;
            if (string.IsNullOrWhiteSpace(resetModel.OldPassword))
            {
                user = db.Users.SingleOrDefault(p => p.Id == resetModel.UserId);
            }
            else
            {
                user = db.Users.SingleOrDefault(p => p.Id == resetModel.UserId && p.UserPassword == resetModel.OldPassword);
            }

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            user.UserPassword = resetModel.Password;
            user.LastLoginDate = DateTime.Now;
            user.NotFirstLogin = true;
            db.Entry(user).State = EntityState.Modified;
            //db.Entry(user).Property(x => x.UserPassword).IsModified = true;

            try
            {
                db.SaveChanges();

                var users = from state in db.States
                            join role in db.Roles on user.RoleId equals role.Id
                            join branch in db.Branches on state.BranchId equals branch.Id
                            join zone in db.Zones on branch.ZoneId equals zone.Id
                            join country in db.Countries on zone.CountryId equals country.Id
                            where state.Id == user.StateId
                            select new UserViewModel
                            {
                                Id = user.Id,
                                UserName = user.UserName,
                                EmailId = user.EmailId,
                                IsActive = user.IsActive,
                                LastLoginDate = user.LastLoginDate,
                                DateOfBirth = SqlFunctions.DateName("month", user.DateOfBirth) + "/" + SqlFunctions.DateName("day", user.DateOfBirth) + "/" + SqlFunctions.DateName("year", user.DateOfBirth),
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                RoleId = user.RoleId,
                                RoleName = role.Name,
                                Status = user.Status,
                                CountryId = user.CountryId,
                                CountryName = country.Name,
                                StateId = user.StateId,
                                StateName = state.Name,
                                NotFirstLogin = user.NotFirstLogin
                            };
                return Ok(users.FirstOrDefault());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(resetModel.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
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