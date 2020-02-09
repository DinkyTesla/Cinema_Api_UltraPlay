using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models
{
    public class ProjectionSeatsSummary
    {
        public ProjectionSeatsSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public ProjectionSeatsSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public int AvailableSeatsCount { get; set; }

        //Need to implement this feature to check for finished projections.
        public DateTime ProjectionDuration { get; set; }
    }
}
