using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageByDynamic
{
    public class GetListProgrammingLanguageByDynamicQuery : IRequest<ProgrammingLanguageListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageByDynamicQueryHander
            : IRequestHandler<GetListProgrammingLanguageByDynamicQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageByDynamicQueryHander(
                IProgrammingLanguageRepository programmingLanguageRepository,
                IMapper mapper
            )
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(
                GetListProgrammingLanguageByDynamicQuery request,
                CancellationToken cancellationToken
            )
            {
                IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListByDynamicAsync(
                    request.Dynamic,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );
                ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(
                    programmingLanguages
                );

                return mappedProgrammingLanguageListModel;
            }
        }
    }
}
