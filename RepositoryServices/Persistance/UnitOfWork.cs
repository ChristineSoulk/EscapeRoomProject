using DatabaseLibrary;
using RepositoryServices.Core;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        public IPlayerRepository Players { get; private set; }

        public IRoomRepository Rooms { get; private set; }

        public IBookingRepository Bookings { get; private set; }

        

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
            Players = new PlayerRepository(context);
            Rooms = new RoomRepository(context);
            Bookings = new BookingRepository(context);
            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
