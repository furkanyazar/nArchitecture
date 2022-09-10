using Core.Persistence.Repositories;

namespace Core.Persistence.Paging;

public class BasePageableModel<T> where T : class, new()
{
    public IList<T> Items { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}
