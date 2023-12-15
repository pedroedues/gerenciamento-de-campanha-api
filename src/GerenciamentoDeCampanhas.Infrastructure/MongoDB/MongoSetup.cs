using GerenciamentoDeCampanhas.Domain.Constantes;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Context;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Security.Authentication;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB
{
    public static partial class MongoDbConfig
    {
        public static void ConfigureMongo(this IServiceCollection services)
        {
            var setttings = MongoClientSettings.FromConnectionString(Parametros.MongoDB.ConnectionString);
            setttings.SslSettings = new() { EnabledSslProtocols = SslProtocols.Tls12 };
            setttings.WaitQueueTimeout = TimeSpan.FromSeconds(15);
            setttings.DirectConnection = true;

            services.AddSingleton<IMongoClient>(c =>
            {
                return new MongoClient(setttings);
            });

            services.AddScoped(c => c.GetService<IMongoClient>().StartSession());
            services.AddScoped<IContextMongo, ContextMongo>();
            services.AddScoped<ICampanhaRepository, CampanhaRepository>();

        }
    }
}
