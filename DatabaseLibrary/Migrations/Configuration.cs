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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            #region SeedingRooms 

            //Room m1 = new Room()
            //{
            //    Title = "",
            //    TotalPrice = ,
            //    Description = "",
            //    Duration = ,
            //    Genre = "",
            //    Capacity = "",
            //    Difficulty = "",
            //    HasActor = "",
            //    Rating = "",
            //    EscapeRate = "",
            //    Language = ""
            //};

            #endregion SeedingRooms
        }
    }
}