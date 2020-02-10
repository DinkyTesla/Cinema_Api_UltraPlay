using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ProjectionModels
{
    public interface ICheckSeatsProjection
    {
        Task<NewSummary> CheckSeat(IReservationCreation projection);
    }
}
