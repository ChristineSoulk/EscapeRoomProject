using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ReservationViewModel
    {
        public int RoomId { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime GameTime { get; set; }
        public Room Room { get; set; }

        public ReservationViewModel()
        {

        }
    }
}
