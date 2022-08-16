using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("Connect")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        

        public virtual DbSet<LanguagePerRoom> LanguagesPerRoom { get; set; }
    }
}
