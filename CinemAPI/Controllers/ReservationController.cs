using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models;
using CinemAPI.Models.Input.Reservation;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    //The endpoint should receive the projection id, row and column which user wants to reserve.
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReservation;
        private readonly IDeleteReservation deleteReservation;
        private readonly IBuyTicket buyTicket;

        public ReservationController(INewReservation newReservation
            , IDeleteReservation deleteReservation, IBuyTicket buyTicket)
        {
            this.newReservation = newReservation;
            this.deleteReservation = deleteReservation;
            this.buyTicket = buyTicket;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(ReservationCreationModel model)
        {
            NewSummary summary = await this.newReservation.New
                (new Reservation(model.ProjectionId, model.Row, model.Column));

            if (summary.IsCreated)
            {
                return Ok($"Reservation with ProjectionId:{model.ProjectionId}, SeatRow:{model.Row}, SeatColumn:{model.Column} has been created successfully!");
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
