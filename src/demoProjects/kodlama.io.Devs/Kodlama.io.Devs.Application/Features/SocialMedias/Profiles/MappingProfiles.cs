using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Domain.Enums;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>()
                .ForMember(
                    c => c.SocialMediaType,
                    opt => opt.MapFrom(c => Enum.GetName(typeof(SocialMediaType), c.SocialMediaType))
                )
                .ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaDto>()
                .ForMember(
                    c => c.SocialMediaType,
                    opt => opt.MapFrom(c => Enum.GetName(typeof(SocialMediaType), c.SocialMediaType))
                )
                .ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaDto>()
                .ForMember(
                    c => c.SocialMediaType,
                    opt => opt.MapFrom(c => Enum.GetName(typeof(SocialMediaType), c.SocialMediaType))
                )
                .ReverseMap();
        }
    }
}
