using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models.Contracts.Projection;
using System.Threading.Tasks;

namespace CinemAPI.Domain.AvailableSeatProjection
{
    public class AvailableSeatProjectionValidation : IAvailableSeatsProjection
    {
        private readonly IProjectionRepository projRepo;
        private readonly IAvailableSeatsProjection availableSeats;

        public AvailableSeatProjectionValidation(IProjectionRepository projRepo, IAvailableSeatsProjection availableSeats)
        {
            this.projRepo = projRepo;
            this.availableSeats = availableSeats;
        }

        public async Task<NewSummary> AvailableSeats(long id)
        {
            IProjection projection = await this.projRepo.GetById(id);

            if (projection == null)
            {
                return new NewSummary(false, $"Projection with id {id} does not exist");
            }

            return await this.availableSeats.AvailableSeats(id);
        }
    }
}
