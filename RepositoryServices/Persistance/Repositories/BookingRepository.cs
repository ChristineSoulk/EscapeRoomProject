using DatabaseLibrary;
using Entities;
using Entities.Models;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context)
        {
        }
        public List<Booking> GetReservations()
        {
            var reservationList = model.Include(y => y.Room).ToList();
            
            return reservationList;
            
        }


        public List<Booking> GetBookingsByRoom(int roomId)
        {
            return model.Where(x => x.RoomId == roomId).ToList();
        }

      
    }
}
