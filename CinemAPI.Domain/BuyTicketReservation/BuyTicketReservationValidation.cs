using CinemAPI.Data;
using CinemAPI.Domain.Constants;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.ReservationModels;
using CinemAPI.Domain.Contracts.Models.TicketModels;
using CinemAPI.Models.Contracts.Reservation;
using System.Threading.Tasks;

namespace CinemAPI.Domain.BuyTicketReservation
{
    public class BuyTicketReservationValidation : IBuyTicket
    {
        private readonly IReservationRepository reservationRepo;
        private readonly IBuyTicket buyTicket;

        public BuyTicketReservationValidation(IReservationRepository reservationRepo, IBuyTicket buyTicket)
        {
            this.reservationRepo = reservationRepo;
            this.buyTicket = buyTicket;
        }

        public async Task<NewTicketSummary> Buy(int id)
        {
            IReservation reservation = await this.reservationRepo.GetById(id);

            if (reservation == null)
            {
                return new NewTicketSummary(false, StringConstants.ReservationDoesNotExist);
            }

            return await buyTicket.Buy(id);
        }
    }
}
