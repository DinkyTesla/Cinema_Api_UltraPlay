using System;

namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservation
    {
        int Id { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        short RoomNumber { get; }

        short Row { get; }

        short Column { get; }

        long ProjectionId { get; }
    }
}

