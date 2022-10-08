using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, UserOperationClaimGetListDto>()
            .ForMember(c => c.UserFullName, opt => opt.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForMember(c => c.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
            .ReverseMap();
        CreateMap<UserOperationClaimListModel, IPaginate<UserOperationClaim>>().ReverseMap();
    }
}