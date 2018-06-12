using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;

namespace SchoolService_Master
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string origin = ConfigurationManager.AppSettings["Cors-Origin"];
            string header = ConfigurationManager.AppSettings["Cors-Header"];
            string methods = ConfigurationManager.AppSettings["Cors-Methods"];
            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute(origin, header, methods);

            // Web API routes
            config.EnableCors(cors);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();

            //config.SuppressHostPrincipal();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "webapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
