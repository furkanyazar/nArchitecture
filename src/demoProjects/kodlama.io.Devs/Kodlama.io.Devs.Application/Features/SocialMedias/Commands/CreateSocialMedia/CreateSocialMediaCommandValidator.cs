using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(s => s.UserId).NotEmpty();
            RuleFor(s => s.UserId).GreaterThan(0);
            RuleFor(s => s.Url).NotEmpty();
            RuleFor(s => s.SocialMediaType).NotEmpty();
        }
    }
}
