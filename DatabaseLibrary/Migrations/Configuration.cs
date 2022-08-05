namespace DatabaseLibrary.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseLibrary.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseLibrary.ApplicationContext context)
        {

            #region SeedingRooms 

            Room m1 = new Room()
            {
                Title = "OUTCAST",
                TotalPrice = 30,
                Description = "papapa",
                Duration = 120,
                Genre = "Horror",
                Capacity = 8,
                Difficulty = "Hard",
                HasActor = false,
                Rating = 4.8,
                EscapeRate = 20,
                Language = "English"
            };
            Room m2 = new Room()
            {
                Title = "The Apocalypse X",
                TotalPrice = 25,
                Description = "lalala",
                Duration = 120,
                Genre = "Horror",
                Capacity = 5,
                Difficulty = "Hardcore",
                HasActor = true,
                Rating = 5,
                EscapeRate = 2,
                Language = "English"
            };
            Room m3 = new Room()
            {
                Title = "The Cellar",
                TotalPrice = 20,
                Description = "totototo",
                Duration = 120,
                Genre = "Horror",
                Capacity = 5,
                Difficulty = "Hard",
                HasActor = true,
                Rating = 5,
                EscapeRate = 1,
                Language = "English"
            };

            context.Rooms.Add(m1);
            context.Rooms.Add(m2);
            context.Rooms.Add(m3);
            context.SaveChanges();

            #endregion SeedingRooms
        }
    }
}
