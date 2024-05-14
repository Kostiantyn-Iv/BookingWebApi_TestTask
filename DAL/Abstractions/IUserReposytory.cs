using DAL.Entities;


namespace DAL.Abstractions
{
    public interface IUserReposytory : IGenericRepository<User>
    {
        public Task<IEnumerable<User>> GetUsersByHotelId(string hotelId);
    }
}
