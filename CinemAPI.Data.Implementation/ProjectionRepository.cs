using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly CinemaDbContext db;

        public ProjectionRepository(CinemaDbContext db)
        {
            this.db = db;
        }

<<<<<<< Updated upstream
        public IProjection Get(int movieId, int roomId, DateTime startDate)
=======
        //Method for getting a given Projection by only id.
        public IProjection GetById(int projectionId)
        {
            return db.Projections.FirstOrDefault(x => x.Id == projectionId);
        }

        //Method for getting available seats.
        public async Task<int> AvailableSeats(int projectionId)
        {
            var currentTime = DateTime.Now;

            var availableSeats = await db.Projections
                                        .Where(p => p.Id == projectionId && p.StartDate.AddMinutes(10) > currentTime)
                                        .Select(p => p.AvailableSeatsCount)
                                        .FirstOrDefaultAsync();

            return availableSeats;
        }

        public IProjection Get(int movieId, int roomId, DateTime startDate, int availableSeatsCount)
>>>>>>> Stashed changes
        {
            return db.Projections.FirstOrDefault(x => x.MovieId == movieId &&
                                                      x.RoomId == roomId &&
                                                      x.StartDate == startDate);
        }

        public IEnumerable<IProjection> GetActiveProjections(int roomId)
        {
            DateTime now = DateTime.UtcNow;

            return db.Projections.Where(x => x.RoomId == roomId &&
                                             x.StartDate > now);
        }

        public void Insert(IProjectionCreation proj)
        {
            Projection newProj = new Projection(proj.MovieId, proj.RoomId, proj.StartDate, proj.AvailableSeatsCount);

            db.Projections.Add(newProj);
            db.SaveChanges();
        }

    }
}