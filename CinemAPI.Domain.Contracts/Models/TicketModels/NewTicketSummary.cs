using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.TicketModels
{
    public class NewTicketSummary
    {
        public NewTicketSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewTicketSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public ITicket TicketReservation { get; set; }
    }
}
