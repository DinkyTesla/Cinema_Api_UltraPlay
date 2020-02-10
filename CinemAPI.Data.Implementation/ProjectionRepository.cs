using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class ProjectionRepository : IProjectionRepository
    {

        //TODO: Async and methods.
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
        public async Task<IProjection> GetById(long projectionId)
        {
            return await db.Projections.FirstOrDefaultAsync(x => x.Id == projectionId);
        }

        public async Task<IProjection> Get(int movieId, int roomId, DateTime startDate)
        {
            return await db.Projections.FirstOrDefaultAsync(x => x.MovieId == movieId &&
                                                      x.RoomId == roomId &&
                                                      x.StartDate == startDate);
        }

        public async Task<IEnumerable<IProjection>> GetActiveProjections(int roomId)
        {
            //TODO: fix time
            DateTime now = DateTime.Now;

            return await db.Projections.Where(x => x.RoomId == roomId &&
                                             x.StartDate > now)
                                             .ToListAsync();
        }

        public async Task Insert(IProjectionCreation proj)
        {
            Projection newProj = new Projection(proj.MovieId, proj.RoomId, proj.StartDate);

            //Initializes initial available seats which should be equal to all seats in the current room.
            newProj.AvailableSeatsCount = InitialSeats(proj.RoomId);
            //Initialize end date.
            newProj.EndDate = CalculateEndDate(proj.MovieId, proj.StartDate);

            db.Projections.Add(newProj);
            await db.SaveChangesAsync();
        }

        //TODO: fix async
        public async Task<bool> CheckIfSeatIsAvailable(long id, int row, int col)
        {
            IQueryable<IReservation> reservations =  this.db.Reservations.Where(x => x.ProjectionId == id);

            foreach (var reservation in reservations)
            {
                if (reservation.Row == row && reservation.Column == col)
                {
                    return false;
                }
            }

            IQueryable<ITicket> tickets =  this.db.Tickets.Where(x => x.ProjectionId == id);

            foreach (var ticket in tickets)
            {
                if (ticket.Row == row && ticket.Column == col)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task DecreaseAvailableSeats(long id)
        {
            var projection = await this.db.Projections.FirstOrDefaultAsync(x => x.Id == id);
            projection.AvailableSeatsCount--;

            await this.db.SaveChangesAsync();
        }

        public async Task IncreaseAvailableSeats(long id, int count)
        {
            var projection = await this.db.Projections.FirstOrDefaultAsync(x => x.Id == id);
            projection.AvailableSeatsCount += count;

            await this.db.SaveChangesAsync();
        }

        public async Task<DateTime> GetProjectionStartDate(long id)
        {
            return await this.db.Projections
                .Where(x => x.Id == id)
                .Select(x => x.StartDate)
                .FirstOrDefaultAsync();
        }
    }
}