using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.Password).MinimumLength(8);
            RuleFor(c => c.Password).Must(ContainLDS);
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.FirstName).MinimumLength(2);
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.LastName).MinimumLength(2);
        }

        private bool ContainLDS(string arg)
        {
            return arg is not null
                && arg.Any(a => char.IsUpper(a))
                && arg.Any(a => char.IsLower(a))
                && arg.Any(a => char.IsDigit(a))
                && arg.Any(a => char.IsSymbol(a) || char.IsPunctuation(a));
        }
    }
}
