using MongoDB.Driver;

namespace WebApplication1.Models
{
    public interface IMongoDbContext
    {
        void Init();
        IMongoDatabase db { get; }
    }
}
