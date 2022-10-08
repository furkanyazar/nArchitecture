using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Services.UserService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetById(int id)
    {
        User user = await _userRepository.GetAsync(u => u.Id == id);
        return user;
    }
}