using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Devs.Application.Features.SocialMedias.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<DeletedSocialMediaDto>
    {
        public int Id { get; set; }

        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public DeleteSocialMediaCommandHandler(
                ISocialMediaRepository socialMediaRepository,
                IMapper mapper,
                SocialMediaBusinessRules socialMediaBusinessRules
            )
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(s => s.Id == request.Id);

                _socialMediaBusinessRules.SocialMediaShouldExistWhenRequested(socialMedia);

                SocialMedia deletedSocialMedia = await _socialMediaRepository.DeleteAsync(socialMedia);
                DeletedSocialMediaDto deletedSocialMediaDto = _mapper.Map<DeletedSocialMediaDto>(deletedSocialMedia);

                return deletedSocialMediaDto;
            }
        }
    }
}
