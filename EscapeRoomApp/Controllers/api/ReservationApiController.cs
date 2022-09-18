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

        public ReservationApiController()
        {
            _reservationService = new ReservationService();
        }

        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return UnitOfWork.Reservations.GetAll().ToList();
        }


        [HttpGet]
        public IEnumerable<Reservation> GetReservationsByRoom(int? roomId)
        {
            if (roomId is null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var room = UnitOfWork.Rooms.GetById(roomId);
            if (room is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return db.Reservations.Where(x => x.RoomId == roomId).ToList();   
        }

        [HttpPost]
        public IHttpActionResult Post(ReservationViewModel model)
        {
            var reservation = _reservationService.MapReservation(model);
            reservation.IsPayed = false;
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
