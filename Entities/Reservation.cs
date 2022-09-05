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
        public int Id { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfPlayers { get; set; }
        [NotMapped]
        public DateTime GameDate { get; set; }
        [NotMapped]
        public DateTime GameTime { get; set; }

        private DateTime _gameDayHour;

        public DateTime GameDayHour
        {
            get { return GameDate.Date.Add(GameTime.TimeOfDay); }
            set { _gameDayHour = value; }
        }
        private decimal _TotalPrice;
        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }
        public bool IsSubscribed { get; set; }
        public bool IsPayed { get; set; }

        

        public Reservation()
        {
            
        }
        public decimal CalculationTotalPrice(decimal startingPricePerPerson,decimal discountPerPerson,int numberOfPlayers)
        {
            return TotalPrice = (numberOfPlayers > 2 ?
                (startingPricePerPerson * numberOfPlayers) - (discountPerPerson * numberOfPlayers * discountPerPerson) : startingPricePerPerson * numberOfPlayers);
        }
    }
}
