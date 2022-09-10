using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidator : AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
