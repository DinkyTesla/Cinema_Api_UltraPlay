using System;

namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservationCreation
    {
        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        short RoomNumber { get; }

        short Row { get; }

        short Column { get; }

        long ProjectionId { get; }

        //TODO: Should this be here?
        //int MovieId { get; set; }

        //int RoomId { get; set; }
    }
}
