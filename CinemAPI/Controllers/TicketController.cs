using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Models;
using CinemAPI.Models.Input.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly INewTicket newTicket;

        public TicketController(INewTicket newTicket)
        {
            this.newTicket = newTicket;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Index(TicketCreationModel model)
        {
            NewSummary summary = await this.newTicket.New(new Ticket
                (model.ProjectionId, model.Row, model.Column));

            if (summary.IsCreated)
            {
                return Ok($"Ticket with ProjectionId:{model.ProjectionId}, SeatRow:{model.Row}, SeatColumn:{model.Column} has been created successfully!");
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
