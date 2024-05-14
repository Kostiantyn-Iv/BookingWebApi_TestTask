using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public sealed class UserRepository : GenericRepository<User>, IUserReposytory
    {
        public UserRepository(BookingDbContext dbContext)
        :base(dbContext){ }

        public async Task<IEnumerable<User>> GetUsersByHotelId(string hotelId)
        {
            IQueryable<User> ans = _dbSet
                .Include(c => c.Room)
                .ThenInclude(c => c.Hotel)
                .Where(c => c.RoomId != null && c.Room!.Hotel!.Id == hotelId);

            return await ans.ToListAsync(); 
        }

        public override async Task<User?> GetByKeyAsync(string key)
        {
            return await _dbSet.Include(c => c.Room).FirstOrDefaultAsync(c => c.Id == key).ConfigureAwait(false);
        }
    }
}
