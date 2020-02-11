using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCheckIfSeatAvailableValidation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewReservation newReservation;

        public NewReservationCheckIfSeatAvailableValidation(IProjectionRepository projRepo, INewReservation newReservation)
        {
            this.projRepo = projRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation reservation)
        {
            bool available = await this.projRepo.CheckIfSeatIsAvailable
                (reservation.ProjectionId, reservation.Row, reservation.Column);

            if (available == false)
            {
                return new NewReservationSummary(false, StringConstants.OccupiedPlace);
            }

            return await newReservation.New(reservation);
        }
    }
}
