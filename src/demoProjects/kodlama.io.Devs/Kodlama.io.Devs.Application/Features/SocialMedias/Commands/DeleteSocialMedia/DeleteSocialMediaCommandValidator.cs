using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator : AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);
        }
    }
}
