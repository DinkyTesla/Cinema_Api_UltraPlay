using CinemAPI.Models.Contracts.Projection;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ProjectionModels
{
    public interface INewProjection
    {
        Task<NewSummary> New(IProjectionCreation projection);
    }
}
