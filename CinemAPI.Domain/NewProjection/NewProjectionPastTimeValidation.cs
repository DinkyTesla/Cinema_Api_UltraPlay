using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewProjection
{
    public class NewProjectionPastTimeValidation : INewProjection
    {
        private readonly IProjectionRepository projectionsRepo;
        private readonly INewProjection newProj;

        public NewProjectionPastTimeValidation(IProjectionRepository projectionsRepo, INewProjection newProj)
        {
            this.projectionsRepo = projectionsRepo;
            this.newProj = newProj;
        }

        public async Task<NewSummary> New(IProjectionCreation projection)
        {
            DateTime currentTime = DateTime.Now;
            DateTime projCreationTime = projection.StartDate;

            if (currentTime > projCreationTime)
            {
                return new NewSummary(false, "You cannot create projections in the past!");
            }
           
            return await newProj.New(projection);
        }

    }
}
