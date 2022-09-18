using Entities;
using Entities.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class ReservationController : BaseClassController
    {
        private readonly IPaypalPaymentService _paypalPaymentsService;
        private readonly IReservationService _reservationService;

        public ReservationController(IPaypalPaymentService paypalPaymentsService, IReservationService reservationService)
        {
            _paypalPaymentsService = paypalPaymentsService;
            _reservationService = reservationService;
        }

        // GET: Reservation
        public ActionResult Index(int roomId, string firstName, string lastName, int numberOfPlayers, string gameDate, string gameTime)
        {
            var room = db.Rooms.Find(roomId);
            DateTime playDate = Convert.ToDateTime(gameDate);
            DateTime playTime = Convert.ToDateTime(gameTime);
            var reservation = new Reservation() { Room = room, RoomId = room.Id, FirstName = firstName, LastName = lastName, NumberOfPlayers = numberOfPlayers, GameDate = playDate, GameTime = playTime };
            reservation.TotalPrice = reservation.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, numberOfPlayers);
            return View(reservation);
        }

        public ActionResult GetAllReservations()
        {
            IEnumerable<Reservation> reservations = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var responseTask = client.GetAsync("ReservationApi");
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

        public ActionResult MakeReservation(int roomId)
        {
            var room = UnitOfWork.Rooms.GetById(roomId);
            var reservation = new Reservation();
            reservation.RoomId = roomId;
            reservation.Room = room;

            DateTime startTime = DateTime.Parse("18:00:00");
            DateTime endTime = DateTime.Parse("22:00:00");

            List<SelectListItem> list = new List<SelectListItem>();
            while (startTime <= endTime)
            {
                list.Add(new SelectListItem() { Text = startTime.ToShortTimeString() + "-" + startTime.AddMinutes(room.Duration).ToShortTimeString(), Value = startTime.ToShortTimeString() });
                startTime = startTime.AddMinutes(room.Duration);

            }

            ViewBag.HourList = list;

            return View(reservation);
        }


        //This is the first phase of paypal payment
        [HttpPost]
        public ActionResult CreatePayment(ReservationViewModel model, string Cancel = null)
        {
            try
            {
                string requestUrlScheme = Request.Url.Scheme;
                string requestUrlAuthority = Request.Url.Authority;

                var paypalCreatedModel = _paypalPaymentsService.CreatePaypalPayment(model, requestUrlScheme, requestUrlAuthority);

                Session.Add("paymentId", paypalCreatedModel.PaymentId);

                //I save the reservation model to this Session so I can retrieve it later to add it to DB
                Session.Add(paypalCreatedModel.PaymentId, model);

                return Redirect(paypalCreatedModel.PaypalRedirectUrl);
            }
            catch
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

        //This is the second and final phase of paypal payment
        public ActionResult ExecutePayment(string Cancel = null)
        {
            try
            {
                string payerId = Request.Params["PayerID"];
                var paymentId = Request.Params["paymentId"];

                //Finalize payment
                var paymentResult = _paypalPaymentsService.ExecutePaypalPayment(payerId, paymentId);

                if (!paymentResult)
                {
                    //throw error or redirect to error page
                }

                //Bring model from session so it can be added to db
                var reservationToBeAdded = Session[paymentId] as ReservationViewModel;

                if (reservationToBeAdded != null)
                {
                    reservationToBeAdded.IsPayed = true;
                    _reservationService.Create(reservationToBeAdded);

                    //Cleanup
                    Session.Remove(payerId);
                    Session.Remove(paymentId);

                    return View("Success");
                }

                //There should be a view for when something goes wrong with payments
                return View("Failure");
            }
            catch
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }
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