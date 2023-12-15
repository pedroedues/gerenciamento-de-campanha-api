using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Setup;
using MongoDB.Driver;
using System.Diagnostics.Metrics;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository
{
    public class CampanhaRepository : ICampanhaRepository
    {
        protected readonly IContextMongo _context;
        protected IMongoCollection<Campanha> Dbset;

        public CampanhaRepository(IContextMongo context)
        {
            _context = context;
            Dbset = _context.GetCollection<Campanha>("campanha");
        }

        public async Task<bool> Atualizar(Campanha campanha, CancellationToken ctx)
        {
            var filter = Builders<Campanha>.Filter;

            await Dbset.ReplaceOneAsync(filter.Eq("_id", campanha.Id), campanha, cancellationToken: ctx);

            return true;
        }

        public async Task<bool> Inserir(Campanha campanha, CancellationToken ctx)
        {
            await Dbset.InsertOneAsync(campanha, null, ctx);

            return true;
        }

        public async Task<Campanha> ObterPeloId(string id, CancellationToken ctx)
        {
            var filter = Builders<Campanha>.Filter;

            var data = await Dbset.FindAsync(filter.Eq("_id", id), cancellationToken: ctx);

            return await data.SingleOrDefaultAsync(ctx);
        }

        public Task<Campanha> ObterTodas(CancellationToken ctx)
        {
            throw new NotImplementedException();
        }
    }
}
