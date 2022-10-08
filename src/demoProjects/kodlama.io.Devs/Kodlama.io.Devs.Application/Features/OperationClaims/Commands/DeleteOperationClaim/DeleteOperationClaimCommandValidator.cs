using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Id).GreaterThan(0);
    }
}