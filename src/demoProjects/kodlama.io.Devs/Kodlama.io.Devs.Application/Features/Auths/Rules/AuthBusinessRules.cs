using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Auths.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user is not null) throw new BusinessException(Messages.EmailAlreadyExists);
        }

        public void UserShouldExistWhenRequested(User user)
        {
            if (user is null) throw new BusinessException(Messages.RequestedUserDoesNotExist);
        }

        public void UserCredentialsMustMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException(Messages.PasswordIsIncorrect);
        }
    }
}