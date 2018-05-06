using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Controllers
{
    public class LoginController : ApiController
    {
        private SchoolServiceContext db = new SchoolServiceContext();
        // GET: webapi/Login comment
        [HttpGet]
        [ResponseType(typeof(UserViewModel)), AllowAnonymous]
        public IHttpActionResult Login(UserViewModel userViewModel)
        {
            var users = from user in db.Users
                        join role in db.Roles on user.RoleId equals role.Id
                        join country in db.Countries on user.CountryId equals country.Id
                        join state in db.States on user.StateId equals state.Id
                        where user.UserName == userViewModel.UserName && user.UserPassword == userViewModel.UserPassword
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
            if (users.Count() == 0)
            {
                return NotFound();
            }
            //var ticket = new FormsAuthenticationTicket(1, userViewModel.UserName, DateTime.Now,
            //                                                       DateTime.Now.AddMinutes(60), true, "",
            //                                                       FormsAuthentication.FormsCookiePath);
            //// Encrypt the ticket
            //var encriptedTicket = FormsAuthentication.Encrypt(ticket);
            //user.authToken = encriptedTicket;
            return Ok(users.FirstOrDefault());
        }

        // GET: webapi/Token comment
        [HttpGet]
        [ResponseType(typeof(object))]
        [Route("webapi/Token")]
        public IHttpActionResult GetToken()
        {
            dynamic AccessToken = new { access_token = ConfigurationManager.AppSettings["ClientId"].ToString(), token_type = "bearer" };
            return Ok(AccessToken);
        }
    }
}
