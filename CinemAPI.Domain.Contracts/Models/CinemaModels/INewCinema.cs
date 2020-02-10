using CinemAPI.Models.Contracts.Cinema;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.CinemaModels
{
    public interface INewCinema
    {
        Task<NewSummary> New(ICinemaCreation cinema);
    }
}
