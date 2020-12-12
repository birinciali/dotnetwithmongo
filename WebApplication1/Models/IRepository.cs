using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IRepository
    {
    }

    public interface IRepository<T> :IRepository where T : Entity
    {
        List<T> Get();
        T Get(string id);
        T Create(T item);
        void Update(string id, T item);
        void Remove(T item);
        void Remove(string id);
        Task<bool> InsertAsync(T item);
        Task<bool> Save(T item);
    }

}
