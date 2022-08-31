using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Constants;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.BrandNameExists);
        }

        public void BrandShouldExistWhenRequested(Brand brand)
        {
            if (brand is null) throw new BusinessException(Messages.RequestedBrandDoesNotExist);
        }
    }
}
