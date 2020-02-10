using CinemAPI.Data;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Ticket;
using System.Threading.Tasks;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketCheckIfAvailableProjection : INewTicket
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewTicket newTicket;

        public NewTicketCheckIfAvailableProjection(IProjectionRepository projRepo, INewTicket newTicket)
        {
            this.projRepo = projRepo;
            this.newTicket = newTicket;
        }

        public async Task<NewSummary> New(ITicketCreation model)
        {
            IProjection projection = await this.projRepo.GetById(model.ProjectionId);

            if (projection == null)
            {
                return new NewSummary(false, $"Projection with id {model.ProjectionId} does not exist");
            }

            return await newTicket.New(model);
        }
    }
}
