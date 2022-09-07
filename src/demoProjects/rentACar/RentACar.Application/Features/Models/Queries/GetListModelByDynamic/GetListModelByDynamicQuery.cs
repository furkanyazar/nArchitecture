using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Models.Models;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler
            : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelByDynamicQueryHandler(
                IModelRepository modelRepository,
                IMapper mapper
            )
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(
                GetListModelByDynamicQuery request,
                CancellationToken cancellationToken
            )
            {
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                    request.Dynamic,
                    include: m => m.Include(c => c.Brand),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                ModelListModel mappedModelListModel = _mapper.Map<ModelListModel>(models);

                return mappedModelListModel;
            }
        }
    }
}
