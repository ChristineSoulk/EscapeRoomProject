using Entities;
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
        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return UnitOfWork.Reservations.GetAll().ToList();
        }
        [HttpPost]
        public IHttpActionResult Create(Reservation reservation)
        {
            
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
