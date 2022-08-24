using DatabaseLibrary;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class BaseClassApiController : ApiController
    {
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;
        public BaseClassApiController()
        {
            UnitOfWork = new UnitOfWork(db);
        }
    }
}