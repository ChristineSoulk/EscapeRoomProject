using DatabaseLibrary;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EscapeRoomApp.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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