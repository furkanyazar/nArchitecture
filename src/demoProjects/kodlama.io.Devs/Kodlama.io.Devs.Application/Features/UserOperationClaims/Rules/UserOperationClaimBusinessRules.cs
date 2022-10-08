using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Constants;
using Kodlama.io.Devs.Application.Services.OperationClaimService;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Application.Services.UserService;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserService _userService;
    private readonly IOperationClaimService _operationClaimService;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserService userService,
        IOperationClaimService operationClaimService)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userService = userService;
        _operationClaimService = operationClaimService;
    }

    public async Task UserOperationClaimCanNotBeDuplicatedWhenInserted(int userId, int operationClaimId)
    {
        IPaginate<UserOperationClaim> result =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == userId && u.OperationClaimId == operationClaimId);
        if (result.Items.Any()) throw new BusinessException(Messages.UserAlreadyHasThisOperationClaim);
    }

    public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
    {
        if (userOperationClaim is null) throw new BusinessException(Messages.RequestedUserOperationClaimDoesNotExist);
    }

    public async Task ThereMustBeUserWhenInserted(int userId)
    {
        User? result = await _userService.GetById(userId);
        if (result is null) throw new BusinessException(Messages.UserNotFound);
    }

    public async Task ThereMustBeOperationClaimWhenInserted(int operationClaimId)
    {
        OperationClaim? result = await _operationClaimService.GetById(operationClaimId);
        if (result is null) throw new BusinessException(Messages.OperationClaimNotFound);
    }
}