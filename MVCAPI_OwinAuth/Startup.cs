﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MVCAPI_OwinAuth.Provider;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(MVCAPI_OwinAuth.Startup))]

namespace MVCAPI_OwinAuth
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder appBuilder)
        {

            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true // https
            };

            // Enable the application to use bearer tokens to authenticate users
            appBuilder.UseOAuthBearerTokens(OAuthOptions);
            appBuilder.UseOAuthAuthorizationServer(OAuthOptions);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            //ConfigureAuth(app);
        }
    }
}