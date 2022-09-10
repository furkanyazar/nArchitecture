using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
