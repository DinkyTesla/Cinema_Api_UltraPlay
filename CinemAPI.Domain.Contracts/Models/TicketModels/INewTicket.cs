using CinemAPI.Domain.Contracts.Models.TicketModels;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.Ticket
{
    public interface INewTicket
    {
        Task<NewTicketSummary> New(ITicketCreation ticket);
    }
}
