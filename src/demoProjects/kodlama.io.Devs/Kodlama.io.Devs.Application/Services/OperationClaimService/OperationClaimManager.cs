using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Services.OperationClaimService;

public class OperationClaimManager : IOperationClaimService
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<OperationClaim> GetById(int id)
    {
        OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == id);
        return operationClaim;
    }
}