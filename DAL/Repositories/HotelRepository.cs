﻿
using DAL.Abstractions;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public sealed class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BookingDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _dbSet.Include(c => c.Rooms).ToListAsync();
        }

        public override async Task<Hotel?> GetByKeyAsync(string key)
        {
            return await _dbSet.Include(c => c.Rooms).FirstOrDefaultAsync(c => c.Id == key).ConfigureAwait(false);
        }
    }
}
