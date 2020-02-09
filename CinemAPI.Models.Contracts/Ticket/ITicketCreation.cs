using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketCreation
    {
        DateTime ProjectionStartDate { get; set; }

        long ProjectionId { get; set; }

        string Movie { get; set; }

        int MovieId { get; set; }

        string Cinema { get; set; }

        short Room { get; set; }

        short Row { get; set; }

        short Col { get; set; }
    }
}
