using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, BaseDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(BaseDbContext context) : base(context) { }
    }
}
