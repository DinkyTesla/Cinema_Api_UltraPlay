using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ReservationModels
{
    public interface ICancelReservation
    {
        Task<NewSummary> CancelReservationsTenMinutesBeforeProjection();
    }
}
