using System;
using System.Threading.Tasks;
using System.Web.Http;
using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Input.Projection;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        //private readonly INewProjection newProj;
        //private readonly IProjectionRepository projRepo;

        //public ProjectionController(INewProjection newProj, IProjectionRepository projRepo)
        //{
        //    this.newProj = newProj;
        //    this.projRepo = projRepo;
        //}

        ////Expose endpoint which will return available seats count for a not
        ////started projection.
        ////TODO: Async, export strings to file.
        //[HttpGet]
        //[Route("api/projection/AvailableSeatsCount/{projectionId}")]
        //public async Task<IHttpActionResult> AvailableSeatsCount(int projectionId)
        //{
        //    IProjection projection = await projRepo.GetById(projectionId);

        //    //If there is no such projection.
        //    if (projection == null)
        //    {
        //        return BadRequest(StringConstants.NoSuchProjection);
        //    }

        //    //If projection has already started.
        //    //TODO: ten minutes before start.
        //    DateTime currenTime = DateTime.Now;
        //    double minutesForLateReservation = -10;

        //    //TODO: Add func for finished projection.
        //    if (projection.EndDate < currenTime)
        //    {
        //        return BadRequest(StringConstants.ProjectionAlreadyStarted);
        //    }

        //    if (projection.StartDate.AddMinutes(minutesForLateReservation) <= currenTime)
        //    {
        //        if (projection.StartDate <= currenTime)
        //        {
        //            return BadRequest(StringConstants.ProjectionAlreadyStarted);
        //        }

        //        return Ok($"Too late for reservations, but several minutes left to buy tickets for the remaining {projection.AvailableSeatsCount} seats");
        //    }


        //    //If there are no seats available.
        //    if (projection.AvailableSeatsCount == 0)
        //    {
        //        return BadRequest("Sorry, no more available seats!");
        //    }

        //    return Ok($"Available seats for this projection: {projection.AvailableSeatsCount}");
        //}

        ////TODO: Async
        //[HttpPost]
        //public async Task<IHttpActionResult> Index(ProjectionCreationModel model)
        //{
        //    //Catch errors for bad input data.
        //    if (ModelState.IsValid)
        //    {
        //        NewSummary summary = await newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate));

        //        if (summary.IsCreated)
        //        {
        //            return Ok("Projection has been created.");
        //        }
        //        else
        //        {
        //            return BadRequest(summary.Message);
        //        }
        //    }

        //    //Catch errors for bad input data.
        //    return BadRequest("Wrong Input Data!");
        //}
        private readonly INewProjection newProj;
        private readonly IAvailableSeatsProjection availableSeatsProj;

        public ProjectionController(INewProjection newProj, IAvailableSeatsProjection availableSeatsProj)
        {
            this.newProj = newProj;
            this.availableSeatsProj = availableSeatsProj;
        }

        [HttpGet]
        public async Task<IHttpActionResult> AvailableSeats(int id)
        {
            var numberOfSeats = await this.availableSeatsProj.AvailableSeats(id);

            if (numberOfSeats.IsCreated)
            {
                return Ok(numberOfSeats);
            }
            else
            {
                return BadRequest(numberOfSeats.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(ProjectionCreationModel model)
        {
            NewSummary summary = await this.newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate));
            
            //Done: Add catch for adding past time.
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