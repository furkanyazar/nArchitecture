using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQueryValidator : AbstractValidator<GetByIdTechnologyQuery>
    {
        public GetByIdTechnologyQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty();
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }
}
