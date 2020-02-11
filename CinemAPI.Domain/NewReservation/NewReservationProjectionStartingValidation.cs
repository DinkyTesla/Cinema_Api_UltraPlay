using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationProjectionStartingValidation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewReservation newReservation;

        public NewReservationProjectionStartingValidation(IProjectionRepository projRepo, INewReservation newReservation)
        {
            this.projRepo = projRepo;
            this.newReservation = newReservation;
        }

        public async Task<NewReservationSummary> New(IReservationCreation model)
        {
            DateTime projectionStartDate = await this.projRepo.GetProjectionStartDate(model.ProjectionId);

            //DONE: Check minutes?
            if (DateTime.Now.AddMinutes(10) > projectionStartDate)
            {
                return new NewReservationSummary(false, StringConstants.ProjectionIsStarting);
            }

            return await newReservation.New(model);
        }
    }
}
