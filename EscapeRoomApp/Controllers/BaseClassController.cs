using DatabaseLibrary;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class BaseClassController : Controller
    {
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;
        public BaseClassController()
        {
            UnitOfWork = new UnitOfWork(db);
        }
    }
}