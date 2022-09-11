using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Features.Authentications.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Authentications.Rules
{
    public class AuthenticationBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any())
                throw new BusinessException(Messages.UserEmailExists);
        }

        public void UserShouldExistWhenRequested(User user)
        {
            if (user is null)
                throw new BusinessException(Messages.RequestedUserDoesNotExist);
        }

        public void UserCredentialsMustMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result)
                throw new BusinessException(Messages.PasswordIncorrect);
        }
    }
}
