using CinemAPI.Models.Contracts.Movie;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.MovieModels
{
    public interface INewMovie
    {
        Task<NewSummary> New(IMovieCreation movie);
    }
}
