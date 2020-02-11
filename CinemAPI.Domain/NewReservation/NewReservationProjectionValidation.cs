using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationProjectionValidation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewReservation newReservation;

        public NewReservationProjectionValidation(IProjectionRepository projRepo, INewReservation newReservation)
        {
            this.projRepo = projRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation model)
        {
            IProjection projection = await this.projRepo.GetById(model.ProjectionId);

            if (projection == null)
            {
                return new NewReservationSummary(false, $"Projection with id {model.ProjectionId} does not exist");
            }

            return await newReservation.New(model);
        }
    }
}
