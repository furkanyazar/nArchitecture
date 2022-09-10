using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
