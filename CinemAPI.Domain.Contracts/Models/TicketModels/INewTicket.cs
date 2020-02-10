using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.Ticket
{
    public interface INewTicket
    {
        Task<NewSummary> New(ITicketCreation ticket);
    }
}
