using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Devs.Application.Features.SocialMedias.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public UpdateSocialMediaCommandHandler(
                ISocialMediaRepository socialMediaRepository,
                IMapper mapper,
                SocialMediaBusinessRules socialMediaBusinessRules
            )
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(s => s.Id == request.Id);

                _socialMediaBusinessRules.SocialMediaShouldExistWhenRequested(socialMedia);

                socialMedia.Url = request.Url;

                SocialMedia updatedSocialMedia = await _socialMediaRepository.UpdateAsync(socialMedia);
                UpdatedSocialMediaDto updatedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(updatedSocialMedia);

                return updatedSocialMediaDto;
            }
        }
    }
}
