using DatabaseLibrary;
using Entities;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationContext db = new ApplicationContext();

        public void Delete(int? id)
        {
            var existing = db.Rooms.Find(id);
            db.Entry(existing).State = System.Data.Entity.EntityState.Deleted;
            Save();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return db.Rooms.ToList();
        }

        public Room GetById(int? id)
        {
            return db.Rooms.Find(id);
        }

        public void Insert(Room room)
        {
            db.Entry(room).State = System.Data.Entity.EntityState.Added;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Room room)
        {
            db.Entry(room).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
    }
}
