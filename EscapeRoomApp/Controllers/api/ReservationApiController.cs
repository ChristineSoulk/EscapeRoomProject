using Entities;
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
    public class ReservationApiController : BaseClassApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationApiController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return UnitOfWork.Reservations.GetAll().ToList();
        }
        [HttpPost]
        public IHttpActionResult Create(ReservationViewModel model)
        {
            _reservationService.Create(model);

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
