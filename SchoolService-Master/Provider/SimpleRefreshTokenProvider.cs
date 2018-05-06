using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.Infrastructure;

namespace SchoolService_Master.Provider
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:clientId"];

            if (string.IsNullOrEmpty(clientid))
            {
                return Task.FromResult<object>(null);
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");
            context.Ticket.Properties.IssuedUtc = DateTime.Now;
            context.Ticket.Properties.ExpiresUtc = DateTime.Now.AddDays(180);
            context.SetToken(refreshTokenId);
            return Task.FromResult<object>(null);
            //using (AuthRepository _repo = new AuthRepository())
            //{
            //    var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            //    var token = new RefreshToken()
            //    {
            //        Id = Helper.GetHash(refreshTokenId),
            //        ClientId = clientid,
            //        Subject = context.Ticket.Identity.Name,
            //        IssuedUtc = DateTime.UtcNow,
            //        ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            //    };



            //    token.ProtectedTicket = context.SerializeTicket();

            //    var result = await _repo.AddRefreshToken(token);

            //    if (result)
            //    {
            //        context.SetToken(refreshTokenId);
            //    }

            //}
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}