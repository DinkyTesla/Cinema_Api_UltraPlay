using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        //Method for initialize the seats based on the all seats in the room.
        int InitialSeats(int roomId);

        DateTime CalculateEndDate(int movieId, DateTime startDate);

        IProjection Get(int movieId, int roomId, DateTime startDate);

        IProjection GetById(int projectionId);

        void Insert(IProjectionCreation projection);

        IEnumerable<IProjection> GetActiveProjections(int roomId);
    }
}