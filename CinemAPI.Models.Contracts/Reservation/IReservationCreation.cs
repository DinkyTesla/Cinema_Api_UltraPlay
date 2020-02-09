using System;

namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservationCreation
    {
        DateTime ProjectionStartDate { get; set; }

        string Movie { get; set; }

        string Cinema { get; set; }

        short Room { get; set; }

        short Row { get; set; }

        short Col { get; set; }

        long ProjectionId { get; set; }

        int MovieId { get; set; }

        int RoomId { get; set; }

    }
}
