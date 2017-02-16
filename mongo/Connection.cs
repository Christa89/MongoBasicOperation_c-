using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace mongo
{
   public class Connection
    {
        public IMongoDatabase Getconnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Mongo"].ToString();
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("PeopleDB");
            return database;
        }
    }
}
