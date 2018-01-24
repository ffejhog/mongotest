using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UTDDesignMongoDemo.Database
{


    public class MongoAccessor
    {
        private const string CONNECTIONSTRING = "mongodb://mongoUser:penguincity123@35.226.81.174";
        private static MongoClient _mongoclient;
        private static IMongoDatabase db;
        public MongoAccessor()
        {
            _mongoclient = new MongoClient(CONNECTIONSTRING);
            db = _mongoclient.GetDatabase("mongoDemo");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("appointments");
        }

        public bool addRecord()
        {
            return true;
        }

    }
}
