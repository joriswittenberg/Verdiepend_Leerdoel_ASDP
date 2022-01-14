

using MongoDB.Bson;
using MongoDB.Driver;
using VerdiependLeerdoel.helpers;
using VerdiependLeerdoel.tables;

namespace VerdiependLeerdoel
{
    public class MongoCRUD
    {
        private IMongoDatabase db;        
        public MongoCRUD(string database)
        {
            var mongoClient = new MongoClient();
            db = mongoClient.GetDatabase(database);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();


        }

        public void insertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public T loadRecordByGameId<T>(string table, string GameId)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("GameId", GameId);

            return collection.Find(filter).First();
        }
        public Game createGame(int numberOfRounds, string gameType, int maxRoundTime)
        {

            Game currentGame = new Game();
            GameInfo gameInfo = new GameInfo(numberOfRounds, gameType, maxRoundTime);

            currentGame.GameId = DateTime.Now.ToString();
            currentGame.GameInfo = gameInfo;

            return currentGame;

        }

        public void addEntitiesInDatabase<T>(string table, string GameId, List<Entity> entities)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("GameId", GameId);
            var update = Builders<T>.Update.Set("Entity", entities);

            collection.UpdateOne(filter, update);
        }
        public void addRoundToDatabase<T>(string table, string GameId, List<Round> rounds)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("GameId", GameId);
            var update = Builders<T>.Update.Set("Round", rounds);

            collection.UpdateOne(filter, update);

        }
    }
}

        


        