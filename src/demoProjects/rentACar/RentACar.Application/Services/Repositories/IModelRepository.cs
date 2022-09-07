using Core.Persistence.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Services.Repositories
{
    public interface IModelRepository : IAsyncRepository<Model>, IRepository<Model> { }
}
