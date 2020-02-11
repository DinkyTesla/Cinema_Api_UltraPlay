using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Domain.Contracts.Models.TicketModels;
using CinemAPI.Models;
using CinemAPI.Models.Input.Ticket;
using CinemAPI.Models.ModelFactory;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly INewTicket newTicket;
        //private readonly IModelFactory modelFactory;

        public TicketController(INewTicket newTicket)
        {
            this.newTicket = newTicket;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(TicketCreationModel model)
        {
            NewTicketSummary summary = await this.newTicket.New(
                new Ticket(model.ProjectionId, model.Row, model.Column));

            if (summary.IsCreated)
            {
                return Ok(summary.Message);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

    }
}
