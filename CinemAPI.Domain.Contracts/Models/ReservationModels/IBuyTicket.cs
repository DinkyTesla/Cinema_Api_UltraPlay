using CinemAPI.Domain.Contracts.Models.TicketModels;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ReservationModels
{
    public interface IBuyTicket
    {
        Task<NewTicketSummary> Buy(int id);
    }
}
