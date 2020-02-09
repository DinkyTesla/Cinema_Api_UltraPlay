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

        public Ticket(int projectionId, short row, short col)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Col = col;
        }

        public Ticket(DateTime projectionStartDate, string movie, string cinema, short room, short row, short column, int projectionId)
        {
            this.ProjectionStartDate = projectionStartDate;
            this.Movie = movie;
            this.Cinema = cinema;
            this.Room = room;
            this.Row = row;
            this.Col = column;
            this.ProjectionId = projectionId;
        }

        public int Id { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string Movie { get; set; }

        public string Cinema { get; set; }

        public short Room { get; set; }

        public short Row { get; set; }
             
        public short Col { get; set; }

        public long ProjectionId { get; set; }

        public int MovieId { get; set; }
    }
}
