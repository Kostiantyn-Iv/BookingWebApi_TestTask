using BLL.Models;

namespace BLL.Abstraction
{
    public interface IRoomService : ICrud<RoomModel>
    {
        public Task RoomReservation(string userId, string roomId);

        public Task RoomRelease(string roomId);

        public Task<IEnumerable<RoomModel>> GetRoomByFilterAsync(string city, int numOfBeds);
    }
}
