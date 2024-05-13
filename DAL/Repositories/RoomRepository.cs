
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
    }
}
