namespace CinemAPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemAPI.Data.EF.CinemaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemAPI.Data.EF.CinemaDbContext context)
        {
            context.Projections.AddOrUpdate(new Models.Projection()
                { MovieId = 2, RoomId = 1, StartDate = DateTime.Parse("2020/02/08 14:23") });

            context.Movies.AddOrUpdate(new Models.Movie() { Name = "Movie1", DurationMinutes = 60 });

            context.Rooms.AddOrUpdate(new Models.Room() { Number = 1, SeatsPerRow = 12, Rows = 12, CinemaId = 1 });

            context.Cinemas.AddOrUpdate(new Models.Cinema() { Name = "Cinema1", Address = "Address1" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
