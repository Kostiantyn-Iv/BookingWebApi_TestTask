using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;

namespace DAL.Repositories
{
    public sealed class UserRepository : GenericRepository<User>, IUserReposytory
    {
        public UserRepository(BookingDbContext dbContext)
        :base(dbContext){ }

    }
}
