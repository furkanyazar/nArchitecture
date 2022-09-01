using Core.Persistence.Repositories;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
