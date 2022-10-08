using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListByUserIdUserOperationClaim;

public class GetListByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
{
    public string[] Roles => new[] { "Admin" };
    public PageRequest PageRequest { get; set; }
    public int UserId { get; set; }

    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListByUserIdUserOperationClaimQuery, UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                u => u.UserId == request.UserId,
                include: u => u.Include(c => c.User).Include(c => c.OperationClaim),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            UserOperationClaimListModel mappedUserOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);

            return mappedUserOperationClaimListModel;
        }
    }
}