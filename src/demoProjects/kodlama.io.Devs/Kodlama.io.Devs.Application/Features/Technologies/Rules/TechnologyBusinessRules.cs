using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any())
                throw new BusinessException(Messages.TechnologyNameExists);
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenUpdated(UpdateTechnologyCommand updateTechnologyCommand)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(
                p => p.Id != updateTechnologyCommand.Id && p.Name == updateTechnologyCommand.Name
            );
            if (result.Items.Any())
                throw new BusinessException(Messages.TechnologyNameExists);
        }

        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology is null)
                throw new BusinessException(Messages.RequestedTechnologyDoesNotExist);
        }
    }
}
