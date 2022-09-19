using Entities.ViewModels;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class CardPaymentController : BaseApiController
    {
        private readonly IBookingService _bookingService;
        private readonly IEmailService _email;
        public CardPaymentController(IBookingService service, IEmailService email)
        {
            _bookingService = service;
            _email = email;
            
        }
        [HttpPost]
        public IHttpActionResult Post(BookingViewModel model)
        {
            var BookingToBeAdded = _bookingService.MapBooking(model);
            BookingToBeAdded.IsPayed = true;
            if (ModelState.IsValid)
            {
                UnitOfWork.Bookings.Insert(BookingToBeAdded);
                _email.SendEmailForBooking(model);
            }
            return Ok();
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
