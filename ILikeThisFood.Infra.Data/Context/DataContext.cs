using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Infra.Data.Context
{
    public class DataContext
    {
        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly string _collectionName;

        public DataContext(string collection)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("ILikeThisFood"); ;
            _collectionName = collection;
        }

    }
}
