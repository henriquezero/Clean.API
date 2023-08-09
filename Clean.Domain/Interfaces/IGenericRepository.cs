namespace Clean.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(Guid id);
        void Add(T item);
        void Remove(T id);
        Task SaveChanges();
    }
}
