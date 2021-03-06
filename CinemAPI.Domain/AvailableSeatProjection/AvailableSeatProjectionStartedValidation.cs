﻿using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Threading.Tasks;

namespace CinemAPI.Domain.AvailableSeatProjection
{
    public class AvailableSeatProjectionStartedValidation : IAvailableSeatsProjection
    {
        private readonly IProjectionRepository projRepo;

        public AvailableSeatProjectionStartedValidation(IProjectionRepository projRepo)
        {
            this.projRepo = projRepo;
        }

        public async Task<NewSummary> AvailableSeats(long id)
        {
            IProjection projection = await this.projRepo.GetById(id);

            if (projection.StartDate < DateTime.Now)
            {
                return new NewSummary(false, StringConstants.ProjectionAlreadyStarted);
            }

            //TODO: fix this message.
            return new NewSummary(true, projection.AvailableSeatsCount.ToString());
        }
    }
}
