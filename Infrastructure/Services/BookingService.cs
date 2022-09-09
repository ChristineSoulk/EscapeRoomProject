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
            Booking Booking = new Booking();
            model.Room = UnitOfWork.Rooms.GetById(model.RoomId);
            Booking.RoomId = model.RoomId;
            Booking.FirstName = model.FirstName;
            Booking.LastName = model.LastName;
            Booking.NumberOfPlayers = model.NumberOfPlayers;
            Booking.GameDate = model.GameDate;
            Booking.GameTime = model.GameTime;
            Booking.TotalPrice = Booking.CalculationTotalPrice(model.Room.StartingPricePerPerson, model.Room.DiscountPerPerson, model.NumberOfPlayers);
            Booking.IsPayed = model.IsPayed;

            return Booking;
        }
    }
}
