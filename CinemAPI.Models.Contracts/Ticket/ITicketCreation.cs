using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketCreation
    {
        int Id { get; set; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        short RoomNumber { get; }
        
        short Row { get; }
        
        short Column { get; }
        
        long ProjectionId { get; }

        int MovieId { get; set; }
    }
}
