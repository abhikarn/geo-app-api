using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SchoolService_Master.Controllers;
using SchoolService_Master.Provider;

[assembly: OwinStartup(typeof(SchoolService_Master.App_Start.Startup))]
namespace SchoolService_Master.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            //Configure(oAuth);
            WebApiConfig.Register(config);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.Use(config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthBearerTokens(oAuthServerOptions);
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        //public void ConfigureOAuth(IAppBuilder app)
        //{
        //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/token"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        Provider = new SimpleAuthorizationServerProvider()
        //    };

        //    // Token Generation
        //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //}
    }
}