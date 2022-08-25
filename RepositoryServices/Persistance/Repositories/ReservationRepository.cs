using DatabaseLibrary;
using Entities;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationContext context) : base(context)
        {
        }
        public List<Reservation> GetReservations()
        {
            var reservationList = model.Include(y => y.Room).ToList();
            
            return reservationList;
            
        }
        //public IEnumerable<Reservation> GetDatesOfReservations()
        //{

        //    //var listDates = model.Select(x => new { x.RoomId,x.GameDayHour}).ToArray().Select(x => new Reservation() { RoomId = x.RoomId, GameDayHour = x.GameDayHour});


        //    //return listDates;
        //}
        

     

    }
}
