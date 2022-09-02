using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
