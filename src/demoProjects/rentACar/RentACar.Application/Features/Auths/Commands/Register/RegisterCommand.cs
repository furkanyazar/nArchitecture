using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using RentACar.Application.Features.Auths.Dtos;
using RentACar.Application.Features.Auths.Rules;
using RentACar.Application.Services.AuthService;
using RentACar.Application.Services.Repositories;

namespace RentACar.Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
        {
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Status = true,
            };
            User createdUser = await _userRepository.AddAsync(newUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredDto registeredDto = new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken,
            };

            return registeredDto;
        }
    }
}