using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime GameTime { get; set; }
        public Room Room { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsPayed { get; set; }

        public BookingViewModel()
        {

        }
    }
}
