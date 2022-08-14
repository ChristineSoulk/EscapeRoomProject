using Entities.Enums;
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
        public string Description { get; set; }
        public int Duration { get; set; }
        public Genre Genre { get; set; }
        public int Capacity { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool HasActor { get; set; }
        public double Rating { get; set; }
        public float EscapeRate { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
        public bool IsActive { get; set; }
        public Dictionary<int, decimal> PricePerPerson { get; set; } = new Dictionary<int, decimal>();

        public Room()
        {
            
        }
    }
}
