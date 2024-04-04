using AutoMapper;
using NTierExample.DTO.UserDtos;
using NTierExample.Entities.AppEntities;
using NTierExample.Entities.AppIdentityEntities;
using NTierExample.ViewModel.UserVms;

namespace NTierExample.BLL.Mapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<AppUser, UserCreateDto>().ReverseMap();
            CreateMap<AppUser, UserUpdateDto>().ReverseMap();
            CreateMap<AppUser, UserDetailVm>().ReverseMap();
            CreateMap<User, AppUser>().ReverseMap();
            CreateMap<User, UserListVm>().ReverseMap();
            CreateMap<UserCreateDto, UserCreateVm>().ReverseMap();
            CreateMap<UserUpdateDto, UserUpdateVm>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
        }
    }
}
