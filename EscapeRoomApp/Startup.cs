using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infrastructure.Interfaces;
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

           // app.UseMiddleware<RequestResponseTimeZoneConverter>();

            var services = new ServiceCollection();
            ConfigureServices(services);

            //This is a default dependency resolver to resolve/get registered services
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());

            //Here I register my custom dependency resolver which contains my DI container(services)
            DependencyResolver.SetResolver(resolver);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Registering controllers(without this the controllers will NOT run, so do not remove this)
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                       .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                       .Where(t => typeof(IController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            //Registering the rest of the services.
            services.AddTransient<IPaypalPaymentService, PaypalPaymentService>();
            services.AddTransient<IReservationService, ReservationService>();

            
        }
    }
}
