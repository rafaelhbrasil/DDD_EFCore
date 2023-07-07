
using EFCoreTest.Domain;

namespace EFCoreTest.Repository.Database.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<int> Commit();
        Task<T> GetByIdAsync(long id);
        void Add(T obj);
        void Update(T obj);
        Task Delete(long id);
        void Delete(T obj);
    }
}
