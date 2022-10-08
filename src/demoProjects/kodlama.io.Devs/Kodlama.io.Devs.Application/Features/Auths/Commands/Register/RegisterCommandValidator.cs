using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.UserForRegisterDto.Email).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Email).EmailAddress();
            RuleFor(c => c.UserForRegisterDto.Password).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Password).MinimumLength(8);
            RuleFor(c => c.UserForRegisterDto.Password).Must(ContainLDS);
            RuleFor(c => c.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.FirstName).MinimumLength(2);
            RuleFor(c => c.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.LastName).MinimumLength(2);
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
