using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeManagerAPI.Models
{
    public class RecipeManager
    {
        private IMongoDatabase database;

        public RecipeManager (string databaseName)
        {
            var client = new MongoClient();
            database = client.GetDatabase(databaseName);
        }

        public void CreateNew<T> (string table, T record)
        {
            // Új rekord hozzáadása.

            var collection = database.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> GetAll<T>(string table)
        {
            // Minden rekord megszerzése.

            var collection = database.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}