using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using System.Threading.Tasks;

namespace CinemAPI.Domain
{
    public class NewProjectionCreation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;

        public NewProjectionCreation(IProjectionRepository projectionsRepo)
        {
            this.projectionsRepo = projectionsRepo;
        }

        public async Task<NewSummary> New(IProjectionCreation projection)
        {
            await projectionsRepo.Insert(new Projection(projection.MovieId, projection.RoomId, projection.StartDate));
            //DONE: Add appropriate message. In the controller.
            return new NewSummary(true);
        }
    }
}