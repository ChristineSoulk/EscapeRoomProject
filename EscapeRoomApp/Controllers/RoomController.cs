using Entities;
using Infrastructure.ObserverManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class RoomController : BaseClassController
    {
        private readonly ISubscribersNotifier _subscribersNotifier;
        public RoomController(ISubscribersNotifier notifier)
        {
            _subscribersNotifier = notifier;
        }
        // GET: Admin/Room
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");

                var postTask = client.PostAsJsonAsync<Room>("RoomApi", room);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    _subscribersNotifier.NotifySubscribersForNewRoom();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server Error!");
            }
            return View(room);
        }
        public ActionResult GetAll()
        {
            IEnumerable<Room> rooms = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var responseTask = client.GetAsync("RoomApi");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Room>>();
                    readTask.Wait();

                    rooms = readTask.Result;
                }
                else
                {
                    rooms = Enumerable.Empty<Room>();
                    ModelState.AddModelError(string.Empty, "Server Error!");
                }
            }
            return View(rooms);
        }
        public ActionResult DetailsOf(int? roomId)
        {
            Room room = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var responseTask = client.GetAsync("RoomApi?roomId=" + roomId.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Room>();

                    room = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error!");
                }
            }
            return Json(room, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? roomId)
        {
            if (roomId is null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var room = UnitOfWork.Rooms.GetById(roomId);
            if (room is null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            return View(room);
        }
        [HttpPut]
        public ActionResult Edit(Room room)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var updateTask = client.PutAsJsonAsync<Room>("RoomApi", room);
                updateTask.Wait();

                var result = updateTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(room);
        }
        public ActionResult Delete(int? roomId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var deleteTask = client.DeleteAsync("RoomApi?roomId=" + roomId.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}