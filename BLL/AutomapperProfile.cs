using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL
{
    // Library for more comfortable model conversion
    public sealed class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Hotel, HotelModel>()
                .ForMember(c => c.RoomIds, u => u.MapFrom(c => c.Rooms!.Select(s => s.Id)))
            .ReverseMap();

            CreateMap<Room, RoomModel>()
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ReverseMap();
        }
    }
}
