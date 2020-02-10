using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ReservationModels
{
    public interface IDeleteReservation
    {
        Task<NewSummary> Delete(int id);
    }
}
