using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Reservation;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Models;
using CinemAPI.Models.Input.Reservation;
using CinemAPI.Models.ModelFactory;
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
        private readonly IModelFactory modelFactory;


        public ReservationController(
            INewReservation newReservation, 
            IModelFactory modelFactory,
            IBuyTicket buyTicket,
            IDeleteReservation deleteReservation
            )
        {
            this.newReservation = newReservation;
            this.deleteReservation = deleteReservation;
            this.buyTicket = buyTicket;
            this.modelFactory = modelFactory;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(ReservationCreationModel model)
        {
            NewReservationSummary summary = await this.newReservation.New(
                    new Reservation(model.ProjectionId, model.Row, model.Column)
                    );

            if (summary.IsCreated)
            {
                //DONE: add ticket object.
                var ticketObj = this.modelFactory.Create(summary.Reservation);
                return Ok(ticketObj);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
