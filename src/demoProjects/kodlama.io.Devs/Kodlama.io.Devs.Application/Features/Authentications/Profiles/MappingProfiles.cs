using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;

namespace Kodlama.io.Devs.Application.Features.Authentications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
        }
    }
}
