
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.Projection
{
    public interface IAvailableSeatsSummary
    {
        Task<NewSummary> AvailableSeatsCount(int projectionId);
    }
}
