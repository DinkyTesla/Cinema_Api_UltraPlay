using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Movie;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IMovie> GetById(int movieId)
        {
            return await this.db.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        }

        public async Task<IMovie> GetByNameAndDuration(string name, short duration)
        {
            return await this.db.Movies.FirstOrDefaultAsync(m => m.Name == name &&
                                                 m.DurationMinutes == duration);
        }

        public async Task Insert(IMovieCreation movie)
        {
            Movie newMovie = new Movie(movie.Name, movie.DurationMinutes);

            this.db.Movies.Add(newMovie);
            await this.db.SaveChangesAsync();
        }

        public async Task<string> GetMovieNameById(int id)
        {
            return await this.db.Movies
                 .Where(m => m.Id == id)
                 .Select(x => x.Name)
                 .FirstOrDefaultAsync();
        }
    }
}