using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MongoDbContext : IMongoDbContext
    {
        private static IMongoDatabase _db;
        private static MongoClient _client;
        private readonly IBookstoreDatabaseSettings _bookstoreDatabaseSettings;
        public IMongoDatabase db => _db;

        public MongoDbContext(IBookstoreDatabaseSettings bookstoreDatabaseSettings)
        {
            _bookstoreDatabaseSettings = bookstoreDatabaseSettings;
            if (_db == null)
                Init();
        }

        public void Init()
        {
            if (_client == null)
                _client = new MongoClient(CreateSettings());

            if (_client != null && _db == null)
                _db = _client.GetDatabase(_bookstoreDatabaseSettings.DatabaseName);
        }

        private MongoClientSettings CreateSettings()
        {
            var internalIdentity = new MongoInternalIdentity("admin", _bookstoreDatabaseSettings.UserName);
            var passwordEvidence = new PasswordEvidence(_bookstoreDatabaseSettings.Password);
            var mongoCredential = new MongoCredential(_bookstoreDatabaseSettings.AuthMechanism, internalIdentity, passwordEvidence);
            return new MongoClientSettings
            {
                Credential = mongoCredential,
                ReadPreference = ReadPreference.SecondaryPreferred,
                WriteConcern = WriteConcern.Acknowledged
            };
        }
    }
}
