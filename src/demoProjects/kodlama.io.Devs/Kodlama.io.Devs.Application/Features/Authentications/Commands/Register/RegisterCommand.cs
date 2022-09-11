using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Kodlama.io.Devs.Application.Features.Authentications.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommand : IRequest<CreatedUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CreatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public RegisterCommandHandler(
                IUserRepository userRepository,
                IMapper mapper,
                AuthenticationBusinessRules authenticationBusinessRules
            )
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<CreatedUserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authenticationBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);

                HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                User user =
                    new()
                    {
                        AuthenticatorType = 0,
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Status = true
                    };

                User createdUser = await _userRepository.AddAsync(user);
                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);

                return createdUserDto;
            }
        }
    }
}
