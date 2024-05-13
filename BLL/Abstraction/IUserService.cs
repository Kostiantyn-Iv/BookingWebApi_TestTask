using BLL.Models;

namespace BLL.Abstraction
{
    public interface IUserService : ICrud<UserModel>
    {
        public Task<IEnumerable<UserModel>> GetUsersByHotelId(string hotelId);
    }
}
