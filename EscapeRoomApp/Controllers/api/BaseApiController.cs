using DatabaseLibrary;
using Infrastructure.ObserverManager;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EscapeRoomApp.Controllers.api
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;
        protected ISubscribersNotifier _notifier;
        public BaseApiController()
        {
            UnitOfWork = new UnitOfWork(db);
           
        }
    }
}