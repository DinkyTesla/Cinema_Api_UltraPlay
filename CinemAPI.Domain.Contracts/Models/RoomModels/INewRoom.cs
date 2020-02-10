using CinemAPI.Models.Contracts.Room;
using System.Threading.Tasks;

namespace CinemAPI.Domain.Contracts.Models.RoomModels
{
    public interface INewRoom
    {
        Task<NewSummary> New(IRoomCreation room);
    }
}
