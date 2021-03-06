﻿using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models.Contracts.Reservation;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationLateValidation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewReservation newReservation;

        public NewReservationLateValidation(IProjectionRepository projRepo, INewReservation newReservation)
        {
            this.projRepo = projRepo;
            this.newReservation = newReservation;
        }
        //TODO: Check for minutes.
        public async Task<NewReservationSummary> New(IReservationCreation model)
        {
            DateTime projectionStartDate = await this.projRepo.GetProjectionStartDate(model.ProjectionId);

            if (DateTime.Now > projectionStartDate)
            {
                return new NewReservationSummary(false, StringConstants.MovieStarted);
            }

            return await newReservation.New(model);
        }
    }
}
