using CinemAPI.Models.Contracts.Room;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemAPI.Models
{
    public class Room : IRoom, IRoomCreation
    {
        public Room()
        {
            this.Projections = new List<Projection>();
        }

        public Room(short number, short seatsPerRow, short rows, int cinemaId)
            : this()
        {
            this.Number = number;
            this.SeatsPerRow = seatsPerRow;
            this.Rows = rows;
            this.CinemaId = cinemaId;
        }

        [Key]
        public int Id { get; set; }

        public short Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }

    }
}