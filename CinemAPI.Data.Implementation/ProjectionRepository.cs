using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Room;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemAPI.Data.Implementation
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly CinemaDbContext db;

        public ProjectionRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        //Initializes initial available seats which should be equal to all seats in the current room.
        public int InitialSeats(int roomId)
        {
            IRoom currentRoom = db.Rooms.FirstOrDefault(r => r.Id == roomId);
            int initialSeats = currentRoom.Rows * currentRoom.SeatsPerRow;

            return initialSeats;
        }

        public DateTime CalculateEndDate(int movieId, DateTime startDate)
        {
            IMovie currentMovie = db.Movies.FirstOrDefault(m => m.Id == movieId);

            DateTime endDate = startDate.AddMinutes(currentMovie.DurationMinutes);

            return endDate;
        }

        //Method for getting a given Projection by only id.
        public IProjection GetById(int projectionId)
        {
            return db.Projections.FirstOrDefault(x => x.Id == projectionId);
        }

        public IProjection Get(int movieId, int roomId, DateTime startDate)
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
            Projection newProj = new Projection(proj.MovieId, proj.RoomId, proj.StartDate);

            //Initializes initial available seats which should be equal to all seats in the current room.
            newProj.AvailableSeatsCount = InitialSeats(proj.RoomId);
            //Initialize end date.
            newProj.EndDate = CalculateEndDate(proj.MovieId, proj.StartDate);

            db.Projections.Add(newProj);
            db.SaveChanges();
        }
    }
}