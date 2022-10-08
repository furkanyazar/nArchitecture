using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.UserForLoginDto.Email).NotEmpty();
        RuleFor(c => c.UserForLoginDto.Email).EmailAddress();
        RuleFor(c => c.UserForLoginDto.Password).NotEmpty();
        RuleFor(c => c.UserForLoginDto.Password).MinimumLength(8);
        RuleFor(c => c.UserForLoginDto.Password).Must(ContainLDS);
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