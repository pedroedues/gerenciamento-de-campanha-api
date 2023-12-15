using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository
{
    public interface ICampanhaRepository
    {
        Task<bool> Inserir(Campanha campanha, CancellationToken ctx);
        Task<bool> Atualizar(Campanha campanha, CancellationToken ctx);
        Task<Campanha> ObterPeloId(string id, CancellationToken ctx);
        Task<Campanha> ObterTodas(CancellationToken ctx);
    }
}
