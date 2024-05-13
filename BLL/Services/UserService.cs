using AutoMapper;
using BLL.Abstraction;
using BLL.Exceptions;
using BLL.Models;
using DAL.Abstractions;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        private readonly IMapper _mapper = mapper;

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(UserModel entity)
        {
            User user = _mapper.Map<User>(entity);

            user.Id = Guid.NewGuid().ToString();
            user.RoomId = null;

            await _unitOfWork.UserReposytory.AddAsync(user).ConfigureAwait(false);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(string key)
        {
            User user = await _unitOfWork.UserReposytory.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"User with key: ({key}) are not exist");

            _unitOfWork.UserReposytory.Delete(user);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            IEnumerable<User> users = await _unitOfWork.UserReposytory.GetAllAsync();

            IEnumerable<UserModel> usersModels = _mapper.Map<IEnumerable<UserModel>>(users);

            return usersModels;
        }

        public async Task<UserModel?> GetByKeyAsync(string key)
        {
            User user = await _unitOfWork.UserReposytory.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"User with key: ({key}) are not exist");

            UserModel userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }

        public Task<IEnumerable<UserModel>> GetUsersByHotelId(string hotelId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserModel entity)
        {
            User user = await _unitOfWork.UserReposytory.GetByKeyAsync(entity.Id!).ConfigureAwait(false)
                ?? throw new NotFoundException($"User with key: ({entity.Id!}) are not exist");

            user.Surname = entity.Surname;
            user.Name = entity.Name!;
            user.PhoneNumber = entity.PhoneNumber;
            user.Email = entity.Email!;
            user.Password = entity.Password!;

            _unitOfWork.UserReposytory.Update(user);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }
    }
}
