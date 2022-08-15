using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PricePerRoomPerPerson
    {
        [Key, Column(Order = 0)]
        public int RoomId { get; set; }

        public Room Room { get; set; }

        [Key, Column(Order = 1)]
        public int NumberOfPlayers { get; set; }

        public decimal PricePerPerson { get; set; }

        //public decimal TotalPrice => NumberOfPlayers * PricePerPerson;

       
        public PricePerRoomPerPerson()
        {

        }
    }
}
