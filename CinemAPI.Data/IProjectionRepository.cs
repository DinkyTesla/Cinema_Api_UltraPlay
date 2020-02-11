using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        //DONE: Async, Methods
        //Method for initialize the seats based on the all seats in the room.
        int InitialSeats(int roomId);

        //Method for adding endDate because we got all we need to calculate at creation.
        DateTime CalculateEndDate(int movieId, DateTime startDate);

        Task<IProjection> Get(int movieId, int roomId, DateTime startDate);

        Task<IProjection> GetById(long projectionId);

        Task Insert(IProjectionCreation projection);

        Task<IEnumerable<IProjection>> GetActiveProjections(int roomId);

        Task<bool> CheckIfSeatIsAvailable(long id, int row, int col);

        Task DecreaseAvailableSeats(long id);

        Task IncreaseAvailableSeats(long id, int count);

        Task<DateTime> GetProjectionStartDate(long id);
    }
}