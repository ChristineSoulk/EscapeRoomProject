using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace EscapeRoomApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            
            string origins = GetAllowedOrigins();
            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);
            

            // Web API routes
            //config.MapHttpAttributeRoutes();
           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
        }
        private static string GetAllowedOrigins()
        {
            //Make a call to the database to get allowed origins and convert to a comma separated string
            return " http://localhost:4200, https://api.sandbox.paypal.com";
        }
    }
}
