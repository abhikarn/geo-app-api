using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using SchoolService_Master.App_Start;
using SchoolService_Master.Models;
using SchoolService_Master.ViewModels;

namespace SchoolService_Master.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UserViewModel usermodel;
            using (SchoolServiceContext _repo = new SchoolServiceContext())
            {
                Users user = _repo.Users.Where(u => u.UserName == context.UserName && u.UserPassword == context.Password).FirstOrDefault();
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                usermodel = user;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Sid, Convert.ToString(usermodel.Id)));
            identity.AddClaim(new Claim(ClaimTypes.Name, usermodel.UserName));

            context.Validated(identity);
            //context.Validated(new ClaimsIdentity(context.Options.AuthenticationType));
        }
    }
}