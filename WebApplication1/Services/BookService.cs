using WebApplication1.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Books> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var internalIdentity = new MongoInternalIdentity("admin", settings.UserName);
            var passwordEvidence = new PasswordEvidence(settings.Password);
            var mongoCredential = new MongoCredential(settings.AuthMechanism, internalIdentity, passwordEvidence);
            var client = new MongoClient(new MongoClientSettings
            {
                Credential = mongoCredential,
                ReadPreference = ReadPreference.SecondaryPreferred,
                WriteConcern = WriteConcern.Acknowledged
            });
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Books>(settings.BooksCollectionName);
        }

        public List<Books> Get() =>
            _books.Find(book => true).ToList();

        public Books Get(string id) =>
            _books.Find(book => book.Id == id).FirstOrDefault();

        public Books Create(Books book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Books bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Books bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}