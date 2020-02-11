﻿using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicket
    {
        int Id { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        short RoomNumber { get; }

        short Row { get; }

        short Column { get; }

        //long ProjectionId { get; }
    }
}
