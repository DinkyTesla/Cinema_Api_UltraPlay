using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Projection;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain.NewProjection
{
    public class NewProjectionUniqueValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly INewProjection newProj;

        public NewProjectionUniqueValidation(IProjectionRepository projectRepo, INewProjection newProj)
        {
            this.projectRepo = projectRepo;
            this.newProj = newProj;
        }

        public NewSummary New(IProjectionCreation proj)
        {
            IProjection projection = projectRepo.Get(proj.MovieId, proj.RoomId, proj.StartDate, proj.AvailableSeatsCount);

            if (projection != null)
            {
                return new NewSummary(false, "Projection already exists");
            }

            return newProj.New(proj);
        }
    }
}