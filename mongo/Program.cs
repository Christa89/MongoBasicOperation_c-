using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Collections;


namespace mongo
{
    class Program
    {
        static void Main(string[] args)
        {
         //   getAllMongo();
          //insertMongo();
            GetMongoById();
        }

        private static void insertMongo()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("PeopleDB");
            var collection = db.GetCollection<peoplesclass>("people");
            peoplesclass p = new peoplesclass();
            p.name = "christa";
            p.city = "hatton";

            collection.InsertOne(p);
        }

        private static void getAllMongo()
        {
            Connection cn = new Connection();
            var collection = cn.Getconnection().GetCollection<peoplesclass>("people");
            var list = collection.Find(new BsonDocument()).ToList();
            foreach (var dox in list)
            {
                Console.WriteLine(dox.name);
                Console.WriteLine(dox.city);
                Console.WriteLine("-----------");
            }
            Console.Read(); 
        }


        private static void  GetMongoById()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("PeopleDB");
            var collection = db.GetCollection<peoplesclass>("people");
            // var filter = Builders<BsonDocument>.Filter.Eq("name", "christa");
            IQueryable<peoplesclass> p = collection.AsQueryable().Where(b => b.city == "colombo");


            foreach(peoplesclass peo  in p )
            {
                Console.WriteLine(peo.name);
                Console.WriteLine(peo.city);
                Console.WriteLine("-----------");
            }

          
           Console.Read();

        }

    } 

    public class peoplesclass
    {
        public ObjectId id { get; set; }
        public string  name{ get; set; }
        public string city { get; set; }
        
    }
}
