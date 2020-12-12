using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebApplication1.Models
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly IMongoCollection<T> _items;

        public Repository(IMongoDbContext context)
        {
            _items = context.db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Get()
        {
            return _items.Find(x => true).ToList();
        }

        public T Get(string id)
        {
            return _items.Find(book => book.Id == id).FirstOrDefault();
        }

        public T Create(T item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, T item) =>
            _items.ReplaceOne(item => item.Id == id, item);

        public void Remove(T item) =>
            _items.DeleteOne(item => item.Id == item.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.Id == id);

        public virtual async Task<bool> InsertAsync(T item)
        {
            await _items.InsertOneAsync(item);
            return true;
        }

        public virtual async Task<bool> Save(T item)
        {
            bool result = false;
            result = await InsertAsync(item);
            return result;
        }
    }
}
