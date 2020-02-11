using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Cinema;
using CinemAPI.Models.Contracts.Room;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemAPI.Data.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaDbContext db;

        public RoomRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IRoom> GetByCinemaAndNumber(int cinemaId, int number)
        {
            return await this.db.Rooms.FirstOrDefaultAsync(r => r.CinemaId == cinemaId &&
                                                r.Number == number);
        }

        public async Task<IRoom> GetById(int id)
        {
            return await this.db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Insert(IRoomCreation room)
        {
            Room newRoom = new Room(room.Number, room.SeatsPerRow, room.Rows, room.CinemaId);

            this.db.Rooms.Add(newRoom);
            await this.db.SaveChangesAsync();
        }
    }
}