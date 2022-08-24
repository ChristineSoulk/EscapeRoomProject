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

        public IReservationRepository Reservations { get; private set; }

        

        public UnitOfWork(ApplicationContext context)
        {
            db = context;
            Players = new PlayerRepository(context);
            Rooms = new RoomRepository(context);
            Reservations = new ReservationRepository(context);
            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
