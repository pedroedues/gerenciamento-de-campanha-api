using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Context;
using MongoDB.Driver;
using System.Diagnostics.Metrics;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository
{
    public class CampanhaRepository : ICampanhaRepository
    {
        protected readonly IContextMongo _context;
        protected IMongoCollection<CampanhaEntity> Dbset;

        public CampanhaRepository(IContextMongo context)
        {
            _context = context;
            Dbset = _context.GetCollection<CampanhaEntity>("campanha");
        }

        public async Task<bool> Atualizar(CampanhaEntity campanha, CancellationToken ctx)
        {
            var filter = Builders<CampanhaEntity>.Filter;

            await Dbset.ReplaceOneAsync(filter.Eq("_id", campanha.Id), campanha, cancellationToken: ctx);

            return true;
        }

        public bool Existe(string id)
        {
            var filter = Builders<CampanhaEntity>.Filter;

            var data = Dbset.Find(filter.Eq("_id", id));

            var result = data.SingleOrDefault();

            return result is not null;
        }

        public bool ExisteLinkAcesso(string linkDeAcesso)
        {
            var filter = Builders<CampanhaEntity>.Filter;

            var data = Dbset.Find(filter.Eq("LinkDeAcesso", linkDeAcesso));

            var result = data.SingleOrDefault();

            return result is not null;
        }

        public async Task<bool> Inserir(CampanhaEntity campanha, CancellationToken ctx)
        {
            await Dbset.InsertOneAsync(campanha, null, ctx);

            return true;
        }

        public async Task<CampanhaEntity> ObterPeloId(string id, CancellationToken ctx)
        {
            var filter = Builders<CampanhaEntity>.Filter;

            var data = await Dbset.FindAsync(filter.Eq("_id", id), cancellationToken: ctx);

            return await data.SingleOrDefaultAsync(ctx);
        }

        public async Task<IEnumerable<CampanhaEntity>> ObterTodos(CancellationToken ctx)
        {
            var filter = Builders<CampanhaEntity>.Filter.Empty;

            var data = await Dbset.FindAsync(filter, cancellationToken: ctx);

            return await data.ToListAsync(ctx);
        }

        public async Task<CampanhaEntity> ObterPorLinkDeAcesso(string linkDeAcesso, CancellationToken ctx)
        {
            var filter = Builders<CampanhaEntity>.Filter;

            var data = await Dbset.FindAsync(filter.Eq("LinkDeAcesso", linkDeAcesso), cancellationToken: ctx);

            return await data.SingleOrDefaultAsync(ctx);
        }
    }
}
