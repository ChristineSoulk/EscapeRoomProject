using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Routing;
using EscapeRoomApp.DIhelpers;
using EscapeRoomApp.Providers;
using Infrastructure.Interfaces;
using Infrastructure.ObserverManager;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(EscapeRoomApp.Startup))]

namespace EscapeRoomApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
           

            var services = new ServiceCollection();
            ConfigureServices(services);

            
            //This is a default dependency resolver to resolve/get registered services
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            //Here I register my custom dependency resolver which contains my DI container(services)
            DependencyResolver.SetResolver(resolver);

            //Mvc Route
            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });


            //Set WebAPI Resolver and register
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = resolver;
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            app.UseWebApi(config);

            string origins = GetAllowedOrigins();
            var cors = new EnableCorsAttribute(origins, "*", "*");
            config.EnableCors(cors);

        }
        private static string GetAllowedOrigins()
        {
            //Make a call to the database to get allowed origins and convert to a comma separated string
            return " http://localhost:4200, https://api.sandbox.paypal.com";
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Registering controllers(without this the controllers will NOT run, so do not remove this)
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                       .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                       .Where(t => typeof(IHttpController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            //Registering the rest of the services.
            services.AddTransient<IPaypalPaymentService, PaypalPaymentService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISubscribersNotifier, SubscribersNotifier>();

            
        }
    }
}
