using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Capacity { get; set; }
        public string Difficulty { get; set; }
        public bool HasActor { get; set; }
        public double Rating { get; set; }
        public float EscapeRate { get; set; }
        public string Language { get; set; }
        public Room()
        {

        }
    }
}
