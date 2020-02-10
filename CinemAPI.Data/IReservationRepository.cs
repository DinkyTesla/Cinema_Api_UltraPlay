using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        Task Insert(IReservationCreation reservation);

        Task<IReservation> GetById(int id);

        Task RemoveReservation(int id);

        Task<int> RemoveAllReservations(long id);
    }
}
