using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
{
    public string[] Roles => new[] { "Admin" };
    public PageRequest PageRequest { get; set; }

    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

            return mappedOperationClaimListModel;
        }
    }
}