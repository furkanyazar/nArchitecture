using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.OperationClaimService;

public interface IOperationClaimService
{
    public Task<OperationClaim> GetById(int id);
}