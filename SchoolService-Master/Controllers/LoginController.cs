using System;
using System.Collections.Generic;
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
        [ResponseType(typeof(UserViewModel)), AllowAnonymous]
        public IHttpActionResult Login(UserViewModel userViewModel)
        {
            Users users = db.Users.Where(x => x.UserName == userViewModel.UserName.Trim() && x.UserPassword == userViewModel.UserPassword.Trim()).FirstOrDefault();
            if (users == null)
            {
                return NotFound();
            }
            var ticket = new FormsAuthenticationTicket(1, userViewModel.UserName, DateTime.Now,
                                                                   DateTime.Now.AddMinutes(60), true, "",
                                                                   FormsAuthentication.FormsCookiePath);
            // Encrypt the ticket
            var encriptedTicket = FormsAuthentication.Encrypt(ticket);
            userViewModel = users;
            userViewModel.authToken = encriptedTicket;
            return Ok(userViewModel);
        }
    }
}
