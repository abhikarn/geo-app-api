using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace SchoolService_Master.Provider
{
    public class ClientIdAuthorizationProvider : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var Id = ConfigurationManager.AppSettings["ClientId"].ToString();
            IEnumerable<string> clientIdHeader;
            actionContext.Request.Headers.TryGetValues("ClientId", out clientIdHeader);
            if (clientIdHeader != null)
            {
                if (!clientIdHeader.First().Equals(Id))
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
        }
    }
}