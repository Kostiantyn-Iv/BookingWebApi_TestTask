
using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public sealed class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(BookingDbContext dbContext) 
            : base(dbContext)
        {}

        public override async Task<Room?> GetByKeyAsync(string key)
        {
            return await _dbSet
                .Include(c => c.User)
                .Include(c => c.Hotel)
                .FirstOrDefaultAsync(c => c.Id == key).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Room>> GetRoomByFilterAsync(string city, int numOfBeds)
        {
            IQueryable<Room> ans = _dbSet
            .Include(c => c.Hotel)
            .Where(c => c.Cup >= numOfBeds && c.Hotel!.City == city && c.UserId == null)
            .OrderBy(c => c.Cup);

            return await ans.ToListAsync().ConfigureAwait(false);
        }
    }
}
