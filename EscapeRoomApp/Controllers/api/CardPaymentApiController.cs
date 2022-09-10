using Entities;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EscapeRoomApp.Controllers.api
{
    public class CardPaymentApiController : BaseClassApiController
    {
        private readonly IReservationService _reservationService;

        public CardPaymentApiController()
        {
            _reservationService = new ReservationService();
        }


        [HttpPost]
        public IHttpActionResult Post(ReservationViewModel model)
        {
            var reservation = _reservationService.MapReservation(model);
            reservation.IsPayed = true;
            if (ModelState.IsValid)
            {
                UnitOfWork.Reservations.Insert(reservation);
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