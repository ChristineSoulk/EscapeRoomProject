using DatabaseLibrary;
using Entities;
using Entities.Exceptions;
using Entities.Models;
using Entities.ViewModels;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Owin.Security.Provider;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IPaypalPaymentService _paypalPaymentsService;
        private readonly IBookingService _BookingService;
        private readonly IEmailService _email;
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;

        public BookingController()
        {
            UnitOfWork = new UnitOfWork(db);
            _paypalPaymentsService = new PaypalPaymentService(_BookingService);
            _email = new EmailService();
            _BookingService = new BookingService();
        }

        public ActionResult PreparationForPayment(int roomId)
        {
            var room = UnitOfWork.Rooms.GetById(roomId);
            var booking = new Booking();
            booking.RoomId = roomId;
            booking.Room = room;

            DateTime startTime = DateTime.Parse("18:00:00");
            DateTime endTime = DateTime.Parse("22:00:00");

            List<SelectListItem> list = new List<SelectListItem>();
            while (startTime <= endTime)
            {
                list.Add(new SelectListItem() { Text = startTime.ToShortTimeString() + "-" + startTime.AddMinutes(room.Duration).ToShortTimeString(), Value = startTime.ToShortTimeString() });
                startTime = startTime.AddMinutes(room.Duration);

            }

            ViewBag.HourList = list;

            return View(booking);
        }


        //This is the first phase of paypal payment
        [HttpPost]
        public ActionResult CreatePayment(BookingViewModel model, string Cancel = null)
        {
            try
            {
                string requestUrlScheme = Request.Url.Scheme;
                string requestUrlAuthority = Request.Url.Authority;

                var paypalCreatedModel = _paypalPaymentsService.CreatePaypalPayment(model, requestUrlScheme, requestUrlAuthority);

                Session.Add("paymentId", paypalCreatedModel.PaymentId);

                //I save the Booking model to this Session so I can retrieve it later to add it to DB
                Session.Add(paypalCreatedModel.PaymentId, model);

                return Redirect(paypalCreatedModel.PaypalRedirectUrl);
            }
            catch
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

        [HttpPost]
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
                var BookingToBeAdded = Session[paymentId] as BookingViewModel;

                if (BookingToBeAdded != null)
                {
                    BookingToBeAdded.IsPayed = true;
                    _BookingService.Create(BookingToBeAdded);
                    _email.SendEmailForBooking(BookingToBeAdded);

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