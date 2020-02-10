using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Data
{
    public interface ITicketRepository
    {
        Task Insert(ITicketCreation ticket);
    }
}
