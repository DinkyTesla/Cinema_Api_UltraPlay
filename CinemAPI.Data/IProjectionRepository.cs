using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
<<<<<<< Updated upstream
        IProjection Get(int movieId, int roomId, DateTime startDate);
=======
        IProjection GetById(int projectionId);

        Task<int> AvailableSeats(int projectionId);

        IProjection Get(int movieId, int roomId, DateTime startDate, int availableSeatsCount);
>>>>>>> Stashed changes

        void Insert(IProjectionCreation projection);

        IEnumerable<IProjection> GetActiveProjections(int roomId);
    }
}