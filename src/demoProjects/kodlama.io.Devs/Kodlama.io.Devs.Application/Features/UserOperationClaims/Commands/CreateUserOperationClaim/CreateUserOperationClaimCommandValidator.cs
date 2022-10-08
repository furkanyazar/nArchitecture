﻿using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserId).GreaterThan(0);
        RuleFor(c => c.OperationClaimId).NotEmpty();
        RuleFor(c => c.OperationClaimId).GreaterThan(0);
    }
}