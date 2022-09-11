using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandValidator : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);
            RuleFor(c => c.Url).NotEmpty();
        }
    }
}
