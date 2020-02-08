using System;

namespace CinemAPI.Models.Contracts.Projection
{
    public interface IProjection
    {
        long Id { get; }

        int RoomId { get; }

        int MovieId { get; }

        DateTime StartDate { get; }

        //Step 1 for code first: Add new field.
        int AvailableSeatsCount { get; }
    }
}