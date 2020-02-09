using CinemAPI.Models.Contracts.Movie;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemAPI.Models
{
    public class Movie : IMovie, IMovieCreation
    {
        public Movie()
        {
            this.Projections = new List<Projection>();
        }

        public Movie(string name, short durationInMinutes)
            : this()
        {
            this.Name = name;
            this.DurationMinutes = durationInMinutes;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public short DurationMinutes { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }
    }
}