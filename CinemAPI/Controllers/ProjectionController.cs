using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Input.Projection;
using System;
using System.Linq;
using System.Web.Http;

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

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        //Expose endpoint which will return available seats count for a not
        //started projection.

        [HttpGet]
        public IHttpActionResult AvailableSeatsCount(int id)
        {
            IProjection projection = projRepo
                                    .GetActiveProjections(id)
                                    .Where(p => p.Id == id)
                                    .FirstOrDefault();

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

            return Ok($"Seats Available: {projection.AvailableSeatsCount}");
        }
    }
}