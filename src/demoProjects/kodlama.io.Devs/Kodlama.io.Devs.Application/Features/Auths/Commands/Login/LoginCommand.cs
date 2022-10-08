using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Auths.Dtos;
using Kodlama.io.Devs.Application.Features.Auths.Rules;
using Kodlama.io.Devs.Application.Services.AuthService;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<LoggedInDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules,
            IAuthService authService)
        {
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);

            _authBusinessRules.UserShouldExistWhenRequested(user);
            _authBusinessRules
                .UserCredentialsMustMatch(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken? refreshToken = await _authService.GetByIpAddressRefreshToken(request.IpAddress);

            if (refreshToken is not null && refreshToken.Expires >= DateTime.UtcNow)
            {
                refreshToken = await _authService.UpdateRefreshToken(refreshToken);
            }
            else
            {
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                refreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            }

            LoggedInDto loggedInDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = refreshToken,
            };

            return loggedInDto;
        }
    }
}