using MongoDB.Bson;
using MongoDB.Driver;

namespace Project9_MongoDbOrderProject.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _mongoDatabase;

        public MongoDbConnection()
        {
           var client = new MongoClient("mongodb://localhost:27017/");
            _mongoDatabase = client.GetDatabase("DbOrder");
        }
        public IMongoCollection<BsonDocument> GetOrdersCollection()
        {
            return _mongoDatabase.GetCollection<BsonDocument>("Orders");
        }
    }
}
