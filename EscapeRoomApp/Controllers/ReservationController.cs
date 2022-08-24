using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class ReservationController : BaseClassController
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllReservations()
        {
            IEnumerable<Reservation> reservations = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/Admin/");
                var responseTask = client.GetAsync("AdminReservationApi");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Reservation>>();
                    reservations = readTask.Result;
                }
                else
                {
                    reservations = Enumerable.Empty<Reservation>();
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return View(reservations);
        }
    }
}