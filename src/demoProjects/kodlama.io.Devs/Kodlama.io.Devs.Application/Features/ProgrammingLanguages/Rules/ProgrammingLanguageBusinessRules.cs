using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguageNameExists);
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Id != updateProgrammingLanguageCommand.Id && p.Name == updateProgrammingLanguageCommand.Name);
            if (result.Items.Any()) throw new BusinessException(Messages.ProgrammingLanguageNameExists);
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage is null) throw new BusinessException(Messages.RequestedProgrammingLanguageDoesNotExist);
        }
    }
}
