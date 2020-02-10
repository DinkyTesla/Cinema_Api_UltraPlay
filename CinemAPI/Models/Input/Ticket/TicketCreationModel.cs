
namespace CinemAPI.Models.Input.Ticket
{
    public class TicketCreationModel
    {
        public long ProjectionId { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}