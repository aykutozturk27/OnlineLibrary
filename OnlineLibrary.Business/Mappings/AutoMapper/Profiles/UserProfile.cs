using AutoMapper;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.Entities.Dtos;

namespace OnlineLibrary.Business.Mappings.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserForLoginDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}
