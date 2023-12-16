using MongoDB.Driver;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Context
{
    public interface IContextMongo : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
