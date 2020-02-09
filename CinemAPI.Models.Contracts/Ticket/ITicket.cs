using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicket
    {
        int Id { get; set; }

        DateTime ProjectionStartDate { get; set; }

        string Movie { get; set; }

        string Cinema { get; set; }

        short Room { get; set; }

        short Row { get; set; }

        short Col { get; set; }
    }
}
