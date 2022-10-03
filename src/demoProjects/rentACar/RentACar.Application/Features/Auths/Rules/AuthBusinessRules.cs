using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using RentACar.Application.Features.Auths.Constants;
using RentACar.Application.Services.Repositories;

namespace RentACar.Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null) throw new BusinessException(Messages.EmailAlreadyExists);
    }
}