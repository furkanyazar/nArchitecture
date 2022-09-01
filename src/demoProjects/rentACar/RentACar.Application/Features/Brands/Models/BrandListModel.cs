using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Models
{
    public class BrandListModel : BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
