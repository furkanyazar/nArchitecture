using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace RentACar.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}