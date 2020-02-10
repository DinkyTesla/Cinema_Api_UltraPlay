using CinemAPI.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CinemAPI.Data.EF
{
    public class MigrationConfiguration : DbMigrationsConfiguration<CinemaDbContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CinemaDbContext context)
        {
            //SeedCinemas(context);
            //SeedMovies(context);
            //SeedRooms(context);
            //SeedProjections(context);
        }

        private void SeedProjections(CinemaDbContext context)
        {
            if (!context.Projections.Any())
            {
                context.Projections.AddOrUpdate(p =>
                p.Id,
                new Projection() { MovieId = 4, RoomId = 1, StartDate = new System.DateTime(2020, 2, 9) },
                new Projection() { MovieId = 5, RoomId = 2, StartDate = new System.DateTime(2020, 2, 9) },
                new Projection() { MovieId = 6, RoomId = 3, StartDate = new System.DateTime(2020, 2, 8) }
                );
            }
        }

        private void SeedMovies(CinemaDbContext context)
        {
            if (!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(m => m.Id,
                new Movie() { Name = "Movie 1", DurationMinutes = 120 },
                new Movie() { Name = "Movie 2", DurationMinutes = 180 },
                new Movie() { Name = "Movie 3", DurationMinutes = 25 }
                );
            }
        }

        private void SeedRooms(CinemaDbContext context)
        {
            if (!context.Rooms.Any())
            {
                context.Rooms.AddOrUpdate(r => r.Id,
              new Room() { Number = 1, Rows = 2, SeatsPerRow = 2, CinemaId = 1 },
              new Room() { Number = 2, Rows = 2, SeatsPerRow = 2, CinemaId = 2 },
              new Room() { Number = 3, Rows = 2, SeatsPerRow = 3, CinemaId = 3 }
              );
            }
        }

        private void SeedCinemas(CinemaDbContext context)
        {
            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddOrUpdate(c => c.Id,
              new Cinema() { Address = " Sofia", Name = "Cinema 1" },
              new Cinema() { Address = " Sofia", Name = "Cinema 2" },
              new Cinema() { Address = " Sofia", Name = "Cinema 3" }
              );
            }
        }
    }
}