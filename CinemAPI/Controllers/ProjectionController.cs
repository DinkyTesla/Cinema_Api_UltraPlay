<<<<<<< Updated upstream
﻿using CinemAPI.Domain.Contracts;
=======
﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
>>>>>>> Stashed changes
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Projection;
using CinemAPI.Models;
using CinemAPI.Models.Input.Projection;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
<<<<<<< Updated upstream

        public ProjectionController(INewProjection newProj)
        {
            this.newProj = newProj;
=======
        private readonly IAvailableSeatsSummary seatsSummary;

        public ProjectionController(INewProjection newProj, IAvailableSeatsSummary seatsSummary)
        {
            this.newProj = newProj;
            this.seatsSummary = seatsSummary;
        }

        //Expose endpoint which will return available seats count for a not
        //started projection.
        [HttpGet]
        public async Task<IHttpActionResult> AvailableSeatsCount(int projectionId)
        {
            var availableSeatsCount = await seatsSummary.AvailableSeatsCount(projectionId);

            if (availableSeatsCount.IsCreated)
            {
                return Ok(availableSeatsCount);
            }
            else
            {
                return BadRequest(availableSeatsCount.Message);
            }

>>>>>>> Stashed changes
        }

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, model.AvailableSeatsCount));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}