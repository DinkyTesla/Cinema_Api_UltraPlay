using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.CinemaModels;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Cinema;
using CinemAPI.Models.Input.Cinema;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class CinemaController : ApiController
    {
        private readonly INewCinema newCinema;

        public CinemaController(INewCinema newCinema)
        {
            this.newCinema = newCinema;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(CinemaCreationModel model)
        {
            NewSummary summary = await this.newCinema.New(new Cinema(model.Name, model.Address));

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