using CinemAPI.Models.Contracts.Cinema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemAPI.Models
{
    public class Cinema : ICinema, ICinemaCreation
    {
        public Cinema()
        {
            this.Rooms = new List<Room>();
        }

        public Cinema(string name, string address)
            : this()
        {
            this.Name = name;
            this.Address = address;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}