using DAL.Abstractions;
using DAL.Repositories;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingDbContext _dbContext;
        private readonly Lazy<IRoomRepository> _roomRepositoryLazy;
        private readonly Lazy<IHotelRepository> _hotelRepositoryLazy;
        private readonly Lazy<IUserReposytory> _userReposytoryLazy;

        private bool _disposed;

        public UnitOfWork(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
            _hotelRepositoryLazy = new Lazy<IHotelRepository>(() => new HotelRepository(dbContext), LazyThreadSafetyMode.PublicationOnly);
            _roomRepositoryLazy = new Lazy<IRoomRepository>(() => new RoomRepository(dbContext), LazyThreadSafetyMode.PublicationOnly);
            _userReposytoryLazy = new Lazy<IUserReposytory>(() => new UserRepository(dbContext), LazyThreadSafetyMode.PublicationOnly);
        }

        public IRoomRepository RoomRepository => _roomRepositoryLazy.Value;

        public IUserReposytory UserReposytory => _userReposytoryLazy.Value;

        public IHotelRepository HotelRepository => _hotelRepositoryLazy.Value;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
