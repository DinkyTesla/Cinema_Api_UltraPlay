using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemAPI.Models.Output.Ticket
{
    public class TicketModel : ITicket
    {
        public int Id { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public short RoomNumber { get; set; }
               
        public short Row { get; set; }
               
        public short Column { get; set; }
    }
}