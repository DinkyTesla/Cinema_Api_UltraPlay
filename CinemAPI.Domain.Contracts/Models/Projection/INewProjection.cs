using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain.Contracts.Models.Projection
{
    public interface INewProjection
    {
        NewSummary New(IProjectionCreation projection);
    }
}