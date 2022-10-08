using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.UserService;

public interface IUserService
{
    public Task<User> GetById(int id);
}