using AutoMapper;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetByIdTechnologyQueryHandler(
                ITechnologyRepository technologyRepository,
                IMapper mapper,
                TechnologyBusinessRules technologyBusinessRules
            )
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology? technology = await _technologyRepository.GetAsync(
                    t => t.Id == request.Id,
                    include: t => t.Include(c => c.ProgrammingLanguage)
                );

                _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

                TechnologyGetByIdDto mappedTechnology = _mapper.Map<TechnologyGetByIdDto>(technology);

                return mappedTechnology;
            }
        }
    }
}
