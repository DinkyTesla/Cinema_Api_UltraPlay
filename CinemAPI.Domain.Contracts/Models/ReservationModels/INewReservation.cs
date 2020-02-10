using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.Reservation
{
    public interface INewReservation
    {
        Task<NewSummary> New(IReservationCreation reservation);
    }
}
