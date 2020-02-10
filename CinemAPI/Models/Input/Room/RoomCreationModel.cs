namespace CinemAPI.Models.Input.Room
{
    public class RoomCreationModel
    {
        public short Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
    }
}