using DAL.Abstractions;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly BookingDbContext _dbContext;

        protected DbSet<T> _dbSet;

        protected GenericRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteByKeyAsync(string key)
        {
            T? entity = await _dbSet.FindAsync(key).ConfigureAwait(false) ?? throw new InvalidOperationException();
            _dbContext.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T?> GetByKeyAsync(string key)
        {
            return await _dbSet.FindAsync(key).ConfigureAwait(false);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
