namespace DAL.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IRoomRepository RoomRepository { get; }

        public IUserReposytory UserReposytory { get; }

        public IHotelRepository HotelRepository { get; }

        Task SaveAsync();
    }
}
