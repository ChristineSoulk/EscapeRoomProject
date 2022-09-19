using DatabaseLibrary;
using Entities;
using Entities.Exceptions;
using Entities.Models;
using Entities.ViewModels;
using Infrastructure.Interfaces;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;

        public BookingService()
        {
            UnitOfWork = new UnitOfWork(db);
        }

        public void Create(BookingViewModel model)
        {
            try
            {
                var BookingToBeAdded = MapBooking(model);
                UnitOfWork.Bookings.Insert(BookingToBeAdded);
            }
            catch (Exception ex)
            {
                throw new WebAppException(ex.Message, ex);
            }
        }

        public Booking MapBooking(BookingViewModel model)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");
            Booking Booking = new Booking();
            var room = UnitOfWork.Rooms.GetById(model.RoomId);
            model.Room = room;
            Booking.RoomId = model.RoomId;
            Booking.Room = model.Room;
            Booking.FirstName = model.FirstName;
            Booking.LastName = model.LastName;
            Booking.Email = model.Email;
            Booking.PhoneNumber = model.PhoneNumber;
            Booking.NumberOfPlayers = model.NumberOfPlayers;
            Booking.GameDate = model.GameDate;
            Booking.GameTime = TimeZoneInfo.ConvertTime(model.GameTime, tz);
            Booking.TotalPrice = Booking.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, model.NumberOfPlayers);
            Booking.IsSubscribed = model.IsSubscribed;
            Booking.IsPayed = model.IsPayed;

            return Booking;
        }
    }
}
