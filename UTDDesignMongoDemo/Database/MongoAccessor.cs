using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using UTDDesignMongoDemo.Models;

namespace UTDDesignMongoDemo.Database
{


    public class MongoAccessor
    {
        private const string CONNECTIONSTRING = "mongodb://mongoUser:penguincity123@35.226.179.59";
        private static MongoClient _mongoclient;
        private static IMongoDatabase db;
        public static IMongoCollection<AppointmentModel> APPOINTMENTCOLLECTION;
        public static IMongoCollection<AppointmentModel> CALENDERCOLLECTION;
        public MongoAccessor()
        {
            _mongoclient = new MongoClient(CONNECTIONSTRING);
            db = _mongoclient.GetDatabase("mongoDemo");
            APPOINTMENTCOLLECTION = db.GetCollection<AppointmentModel>("appointments");
            
        }

        public void addRecord(AppointmentModel model, IMongoCollection<AppointmentModel> collection)
        {
            collection.InsertOne(model);
        }

        public async void addManyRecords(List<AppointmentModel> modelList, IMongoCollection<AppointmentModel> collection)
        {
            await collection.InsertManyAsync(modelList); //This says don't return the data until this task is completed(But becuase their is no return, it doesn't matter)
        }

        public List<AppointmentModel> returnAll(IMongoCollection<AppointmentModel> collection)
        {
            List<AppointmentModel> list = collection.Find(_ => true).ToList();
            return list;
        }

        public void deleteAll(IMongoCollection<AppointmentModel> collection)
        {
            collection.DeleteMany(_ => true); // Delete all values
        }

    }
}
