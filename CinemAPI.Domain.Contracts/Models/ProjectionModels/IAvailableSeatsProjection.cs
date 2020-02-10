using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.ProjectionModels
{
    public interface IAvailableSeatsProjection
    {
        Task<NewSummary> AvailableSeats(long id);
    }
}
