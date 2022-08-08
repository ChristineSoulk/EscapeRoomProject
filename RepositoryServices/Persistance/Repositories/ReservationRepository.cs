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
            var listDates = model.Include(x => x.Player).Include(y => y.Room).ToList();

            return listDates;
            
        }
    }
}
