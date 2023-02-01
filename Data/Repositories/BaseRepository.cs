using Domain.Common;

namespace Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
    where T : Entity<int>
{
    private List<T> _itensToAdd;

    public BaseRepository()
    {
        _itensToAdd = new List<T>();
        Dataset = new List<T>();
    }
    
    protected List<T> Dataset { get; set; }

    public IEnumerable<T> Get(Func<T, bool> predicate) => Dataset.Where(predicate);

    public T? Find(int id) => Dataset.FirstOrDefault(obj => obj.Id == id);

    public T Add(T item)
    {
        _itensToAdd.Add(item);
        return item;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> items)
    {
        _itensToAdd.AddRange(items);
        return items;
    }

    public void Remove(T item) => _itensToAdd.Remove(item);

    public void SaveChanges() => Dataset.AddRange(_itensToAdd);
}