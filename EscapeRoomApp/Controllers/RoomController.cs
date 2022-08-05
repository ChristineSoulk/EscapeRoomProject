using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository RoomRepo;
        public RoomController()
        {
            RoomRepo = new RoomRepository();
        }
        // GET: Room
        [HttpGet]
        public ActionResult Index()
        {
            var rooms = RoomRepo.GetAllRooms();

            return Json(rooms,JsonRequestBehavior.AllowGet);
        }
    }
}