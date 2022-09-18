using DatabaseLibrary;
using Entities;
using Entities.Exceptions;
using Infrastructure.Interfaces;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        protected ApplicationContext db = new ApplicationContext();
        protected UnitOfWork UnitOfWork;

        public ReservationService()
        {
            UnitOfWork = new UnitOfWork(db);
        }

        public void Create(ReservationViewModel model)
        {
            try
            {
                var reservationToBeAdded = MapReservation(model);
                UnitOfWork.Reservations.Insert(reservationToBeAdded);
            }
            catch (Exception ex)
            {
                throw new WebAppException(ex.Message, ex);
            }
        }

        public Reservation MapReservation(ReservationViewModel model)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");
            Reservation reservation = new Reservation();
            model.Room = UnitOfWork.Rooms.GetById(model.RoomId);
            reservation.RoomId = model.RoomId;
            reservation.FirstName = model.FirstName;
            reservation.LastName = model.LastName;
            reservation.NumberOfPlayers = model.NumberOfPlayers;
            reservation.GameDate = model.GameDate;
            reservation.GameTime = TimeZoneInfo.ConvertTime(model.GameTime, tz);
            reservation.TotalPrice = reservation.CalculationTotalPrice(model.Room.StartingPricePerPerson, model.Room.DiscountPerPerson, model.NumberOfPlayers);
            reservation.IsPayed = model.IsPayed;

            return reservation;
        }


       

    }
}
