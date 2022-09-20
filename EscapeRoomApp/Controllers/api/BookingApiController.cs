using DatabaseLibrary;
using Entities;
using Entities.Exceptions;
using Entities.Models;
using Entities.ViewModels;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EscapeRoomApp.Controllers.api
{
    
    public class BookingApiController : BaseApiController
    {
        private readonly IBookingService _BookingService;
        private readonly IEmailService _email;

        public BookingApiController(IBookingService service,IEmailService email)
        {
            _BookingService = service;
            _email = email;
        }
        

        [HttpGet]
        public IEnumerable<Booking> GetAllBookings()
        {
            return UnitOfWork.Bookings.GetAll().ToList();
        }


        [HttpGet]
        public IEnumerable<Booking> GetBookingsByRoomId(int? roomId)
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
            return UnitOfWork.Bookings.GetBookingsByRoom(room.Id);
        }

        [HttpPost]
        public IHttpActionResult StoreBooking(BookingViewModel model)
        {
            //BookingService _BookingService =new BookingService();

            try
            {
                var BookingToBeAdded = _BookingService.MapBooking(model);
                BookingToBeAdded.IsPayed = false;
                UnitOfWork.Bookings.Insert(BookingToBeAdded);
                _email.SendEmailForBooking(model);
            }
            catch (Exception ex)
            {
                throw new WebAppException(ex.Message, ex);
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
