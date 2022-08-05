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
    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationContext db = new ApplicationContext();
        
        public Player GetById(int? id)
        {
            var player = db.Players.Find(id);
            return player;
        }

        public void Insert(Player player)
        {
            db.Entry(player).State = EntityState.Added;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            Save();
        }
    }
}
