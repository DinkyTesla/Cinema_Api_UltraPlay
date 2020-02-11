using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ProjectionModels;
using CinemAPI.Models.Contracts.Movie;
using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewProjection
{
    public class NewProjectionNextOverlapValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionNextOverlapValidation(IProjectionRepository projectRepo, IMovieRepository movieRepo, INewProjection newProj)
        {
            this.projectRepo = projectRepo;
            this.movieRepo = movieRepo;
            this.newProj = newProj;
        }

        public async Task<NewSummary> New(IProjectionCreation projection)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = await this.projectRepo.GetActiveProjections(projection.RoomId);

            //TODO: add await?
            IProjection nextProjection =  movieProjectionsInRoom.Where(x => x.StartDate > projection.StartDate)
                                                                       .OrderBy(x => x.StartDate)
                                                                       .FirstOrDefault();
            //TODO: Take Endate from table.
            if (nextProjection != null)
            {
                IMovie currentMovie = await this.movieRepo.GetById(projection.MovieId);
                IMovie nextProjectionMovie = await this.movieRepo.GetById(nextProjection.MovieId);

                DateTime curProjectionEndTime = projection.StartDate.AddMinutes(currentMovie.DurationMinutes);

                if (curProjectionEndTime >= nextProjection.StartDate)
                {
                    return new NewSummary(false, $"Projection overlaps with next one:" +
                    $" {nextProjectionMovie.Name} at {nextProjection.StartDate}");
                }
            }

            return await newProj.New(projection);
        }
    }
}