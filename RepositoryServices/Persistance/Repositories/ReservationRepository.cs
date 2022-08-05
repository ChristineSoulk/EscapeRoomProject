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
    public class ReservationRepository : IReservationRepository
    {
        private ApplicationContext db = new ApplicationContext();
       
        public void Delete(int? id)
        {
            var existing = db.Reservations.Find(id);
            db.Entry(existing).State = EntityState.Deleted;
            Save();
        }

        public Reservation GetById(int? id)
        {
            var reservation = db.Reservations.Find(id);

            return reservation;
        }

        public void Insert(Reservation reservation)
        {
            db.Entry(reservation).State = EntityState.Added;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            db.Entry(reservation).State = EntityState.Modified;
            Save();
        }
    }
}
