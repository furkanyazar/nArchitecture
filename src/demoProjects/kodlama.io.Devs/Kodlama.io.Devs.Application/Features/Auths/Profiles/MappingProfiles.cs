using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Features.Auths.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserForRegisterDto, User>().ReverseMap();
        }
    }
}