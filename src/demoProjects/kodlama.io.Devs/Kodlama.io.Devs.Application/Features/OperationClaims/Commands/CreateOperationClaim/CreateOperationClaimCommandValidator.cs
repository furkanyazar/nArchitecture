using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
    }
}