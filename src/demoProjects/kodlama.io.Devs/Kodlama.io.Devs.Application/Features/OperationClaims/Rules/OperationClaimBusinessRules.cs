using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(o => o.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.OperationClaimNameExists);
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenUpdated(int id, string name)
    {
        IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(o => o.Id != id && o.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.OperationClaimNameExists);
    }

    public void OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
    {
        if (operationClaim is null) throw new BusinessException(Messages.RequestedOperationClaimDoesNotExist);
    }
}