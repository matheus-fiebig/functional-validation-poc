namespace Domain.Common;

public interface IBaseRepository<T>
{
    IEnumerable<T> Get(Func<T, bool> predicate);
    T? Find(int id);
    T Add(T item);
    IEnumerable<T> AddRange(IEnumerable<T> items);
    void Remove(T item);
    void SaveChanges();
    
}