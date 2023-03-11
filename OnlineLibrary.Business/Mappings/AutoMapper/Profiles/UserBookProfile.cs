using AutoMapper;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.Business.Mappings.AutoMapper.Profiles
{
    public class UserBookProfile : Profile
    {
        public UserBookProfile()
        {
            CreateMap<UserBook, UserBookListDto>().ReverseMap();
            CreateMap<UserBook, UserBookAddDto>().ReverseMap();
            CreateMap<UserBook, UserBookReservationDto>().ReverseMap();
        }
    }
}
