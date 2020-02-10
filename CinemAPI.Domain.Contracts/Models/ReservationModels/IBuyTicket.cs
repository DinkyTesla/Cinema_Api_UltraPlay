using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ReservationModels
{
    public interface IBuyTicket
    {
        Task<NewSummary> Buy(int id);
    }
}
