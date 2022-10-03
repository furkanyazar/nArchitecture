using Core.Persistence.Repositories;
using Core.Security.Entities;
using RentACar.Application.Services.Repositories;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}