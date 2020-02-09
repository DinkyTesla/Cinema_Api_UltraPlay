using System;
using System.Web.Http;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Input.Projection;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionRepository projRepo;

        public ProjectionController(INewProjection newProj, IProjectionRepository projRepo)
        {
            this.newProj = newProj;
            this.projRepo = projRepo;
        }
        //Expose endpoint which will return available seats count for a not
        //started projection.
        [HttpGet]
        [Route("api/projection/AvailableSeatsCount/{projectionId}")]
        public IHttpActionResult AvailableSeatsCount(int projectionId)
        {
            IProjection projection = projRepo.GetById(projectionId);

            //If there is no such projection.
            if (projection == null)
            {
                return BadRequest("No such Projection!");
            }

            //If projection has already started.
            if (projection.StartDate <= DateTime.UtcNow)
            {
                return BadRequest("Projection already started!");
            }

            //If there are no seats available.
            if (projection.AvailableSeatsCount == 0)
            {
                return BadRequest("Sorry, no more available seats!");
            }

            return Ok($"Available seats for this projection: {projection.AvailableSeatsCount}");
        }

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate));

            if (summary.IsCreated)
            {
                return Ok("Projection has been created.");
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}