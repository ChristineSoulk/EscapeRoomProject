using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Cors;

namespace EscapeRoomApp.DIhelpers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DefaultDependencyResolver : System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        protected IServiceProvider serviceProvider;
        
        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDependencyScope BeginScope()
        {
            return new DefaultDependencyResolver(this.serviceProvider.CreateScope().ServiceProvider);
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }

        public void Dispose()
        {
            
        }
    }
}