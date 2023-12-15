using GerenciamentoDeCampanhas.Domain.Constantes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Context
{
    public class ContextMongo : IContextMongo
    {
        private IMongoDatabase? Database { get; set; }
        private IClientSessionHandle? Session { get; set; }
        private MongoClient? MongoClient { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(collectionName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Session?.Dispose();
        }

        private void ConfigureMongo()
        {
            if (MongoClient is not null)
                return;

            MongoClient = new MongoClient(Parametros.MongoDB.ConnectionString);
            Database = MongoClient.GetDatabase(Parametros.MongoDB.Database);
        }
    }
}
