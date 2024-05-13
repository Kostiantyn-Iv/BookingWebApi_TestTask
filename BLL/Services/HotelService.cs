using AutoMapper;
using BLL.Abstraction;
using BLL.Exceptions;
using BLL.Models;
using DAL.Abstractions;
using DAL.Entities;

namespace BLL.Services
{
    public sealed class HotelService(IMapper mapper, IUnitOfWork unitOfWork) : IHotelService
    {
        private readonly IMapper _mapper = mapper;

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task AddAsync(HotelModel entity)
        {
            Hotel hotel = _mapper.Map<Hotel>(entity);

            hotel.Id = Guid.NewGuid().ToString();

            await _unitOfWork.HotelRepository.AddAsync(hotel).ConfigureAwait(false);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(string key)
        {
            Hotel hotel = await _unitOfWork.HotelRepository.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"Hotel with key: ({key}) are not exist");

            _unitOfWork.HotelRepository.Delete(hotel);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<HotelModel>> GetAllAsync()
        {
            IEnumerable<Hotel> hotels = await _unitOfWork.HotelRepository.GetAllAsync();

            IEnumerable<HotelModel> hotelModels = _mapper.Map<IEnumerable<HotelModel>>(hotels);

            return hotelModels;
        }

        public async Task<HotelModel?> GetByKeyAsync(string key)
        {
            Hotel hotel = await _unitOfWork.HotelRepository.GetByKeyAsync(key).ConfigureAwait(false)
                ?? throw new NotFoundException($"Hotel with key: ({key}) are not exist");

            HotelModel hotelModel = _mapper.Map<HotelModel>(hotel);

            return hotelModel;
        }

        public async Task UpdateAsync(HotelModel entity)
        {
            Hotel hotel = await _unitOfWork.HotelRepository.GetByKeyAsync(entity.Id).ConfigureAwait(false)
                ?? throw new NotFoundException($"Hotel with key: ({entity.Id}) are not exist");

            hotel.City = entity.City!;
            hotel.Name = entity.Name!;
            hotel.Rooms = null;

            _unitOfWork.HotelRepository.Update(hotel);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }
    }
}
