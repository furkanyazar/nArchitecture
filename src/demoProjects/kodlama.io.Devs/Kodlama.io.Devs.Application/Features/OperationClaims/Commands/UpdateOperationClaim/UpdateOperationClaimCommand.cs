using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
            OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);

            _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(operationClaim);
            await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

            operationClaim.Name = request.Name;

            OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);
            UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

            return updatedOperationClaimDto;
        }
    }
}