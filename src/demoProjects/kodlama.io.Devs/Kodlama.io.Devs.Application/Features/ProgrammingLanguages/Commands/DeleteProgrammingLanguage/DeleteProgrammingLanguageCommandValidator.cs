using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
