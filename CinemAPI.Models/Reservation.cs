using CinemAPI.Models.Contracts.Reservation;
using System;

namespace CinemAPI.Models
{
    public class Reservation : IReservation, IReservationCreation
    {
        public Reservation()
        {
        }

        public Reservation(long projectionId, short row, short column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        public Reservation(
            DateTime projectionStartDate,
            string movieName,
            string cinemaName, 
            short roomNumber, 
            short row, 
            short column, 
            long projectionId)
        {
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNumber = roomNumber;
            this.Row = row;
            this.Column = column;
            this.ProjectionId = projectionId;
        }

        public int Id { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public short RoomNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }

        public long ProjectionId { get; set; }

        public Projection Projection { get; set; }

        //TODO: should be implemented?
        public int MovieId { get ; set ; }

        public int RoomId { get ; set ; }
    }
}
