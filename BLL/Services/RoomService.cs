using AutoMapper;
using BLL.Abstraction;
using BLL.Exceptions;
using BLL.Models;
using DAL.Abstractions;
using DAL.Entities;

namespace BLL.Services
{
    public sealed class RoomService(IUnitOfWork unitOfWork, IMapper mapper) : IRoomService
    {
        private readonly IMapper _mapper = mapper;

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(RoomModel entity)
        {
            Room room = _mapper.Map<Room>(entity);

            room.UserId = null;

            room.Id = Guid.NewGuid().ToString();

            room.Hotel = await _unitOfWork.HotelRepository.GetByKeyAsync(entity.HotelId).ConfigureAwait(false)
                ?? throw new NotFoundException($"Hotel with key: ({entity.HotelId}) are not exist");

            await _unitOfWork.RoomRepository.AddAsync(room).ConfigureAwait(false);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(string key)
        {
           Room room = await _unitOfWork.RoomRepository.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"Room with key: ({key}) are not exist");

            _unitOfWork.RoomRepository.Delete(room);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            IEnumerable<Room> rooms = await _unitOfWork.RoomRepository.GetAllAsync();

            IEnumerable<RoomModel> roomsModels = _mapper.Map<IEnumerable<RoomModel>>(rooms);

            return roomsModels;
        }

        public async Task<RoomModel?> GetByKeyAsync(string key)
        {
            Room room = await _unitOfWork.RoomRepository.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"Room with key: ({key}) are not exist");

            RoomModel roomModel = _mapper.Map<RoomModel>(room);

            return roomModel;
        }

        public async Task RoomRelease(string roomId)
        {
            Room room = await _unitOfWork.RoomRepository.GetByKeyAsync(roomId).ConfigureAwait(false)
                ?? throw new NotFoundException($"Room with key: ({roomId}) are not exist");

            if (room.UserId is null) throw new BadRequestException($"Room with ID:{roomId} is already Released");

            User user = await _unitOfWork.UserReposytory.GetByKeyAsync(room.UserId).ConfigureAwait(false)
                ?? throw new NotFoundException($"User with key: ({room.UserId}) are not exist");

            room.UserId = null;
            user.RoomId = null;

            _unitOfWork.RoomRepository.Update(room);
            _unitOfWork.UserReposytory.Update(user);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task RoomReservation(string userId, string roomId)
        {
            Room room = await _unitOfWork.RoomRepository.GetByKeyAsync(roomId).ConfigureAwait(false)
                ?? throw new NotFoundException($"Room with key: ({roomId}) are not exist");

            User user = await _unitOfWork.UserReposytory.GetByKeyAsync(userId).ConfigureAwait(false)
                ?? throw new NotFoundException($"User with key: ({userId}) are not exist");

            if (user.RoomId != null) throw new BadRequestException($"User with this ID:{userId} has already reserved a room");
            if (room.UserId != null) throw new BadRequestException($"Room with ID:{roomId} is already reserved");

            room.UserId = userId;
            user.RoomId = roomId;

            _unitOfWork.RoomRepository.Update(room);
            _unitOfWork.UserReposytory.Update(user);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(RoomModel entity)
        {
            Room room = await _unitOfWork.RoomRepository.GetByKeyAsync(entity.Id!).ConfigureAwait(false)
                ?? throw new NotFoundException($"Room with key: ({entity.Id}) are not exist");

            room.UserId = null;
            room.Num = entity.Num;
            room.Cup = entity.Cup;
            room.HotelId = entity.HotelId;

            Hotel hotel = await _unitOfWork.HotelRepository.GetByKeyAsync(entity.HotelId).ConfigureAwait(false)
                ?? throw new NotFoundException($"Hotel with key: ({entity.Id}) are not exist");

            room.Hotel = hotel;

            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }
    }
}
