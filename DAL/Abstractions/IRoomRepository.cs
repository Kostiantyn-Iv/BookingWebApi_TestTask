using DAL.Entities;

namespace DAL.Abstractions
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        public Task<IEnumerable<Room>> GetRoomByFilterAsync(string city, int numOfBeds);
    }
}
