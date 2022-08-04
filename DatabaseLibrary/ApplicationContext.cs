using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
