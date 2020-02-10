namespace CinemAPI.Models.Contracts.Room
{
    public interface IRoomCreation
    {
        short Number { get; }

        short SeatsPerRow { get; }

        short Rows { get; }

        int CinemaId { get; }
    }
}