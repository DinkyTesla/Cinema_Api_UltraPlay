using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Models
{
    public class Ticket : ITicket, ITicketCreation
    {
        public Ticket()
        {
        }

        public Ticket(long projectionId, short row, short col)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = col;
        }

        public Ticket(DateTime projectionStartDate, string movieName, string cinemaName, short roomNumber, short row, short column, long projectionId)
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
    }
}
