using MongoDB.Driver;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Setup
{
    public interface IContextMongo : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
