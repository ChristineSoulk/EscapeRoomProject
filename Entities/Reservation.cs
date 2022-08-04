using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        [Key, Column(Order = 0)]
        public int RoomId { get; set; }

        [Key, Column(Order = 1)]
        public int PlayerId { get; set; }

        public Room Room { get; set; }

        public Player Player { get; set; }

        public int NumberOfPlayers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        public Reservation()
        {

        }

    }
}
