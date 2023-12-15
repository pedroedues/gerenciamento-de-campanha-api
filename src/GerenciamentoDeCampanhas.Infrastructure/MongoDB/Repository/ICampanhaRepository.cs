using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository
{
    public interface ICampanhaRepository
    {
        Task<bool> Inserir(CampanhaEntity campanha, CancellationToken ctx);
        Task<bool> Atualizar(CampanhaEntity campanha, CancellationToken ctx);
        Task<CampanhaEntity> ObterPeloId(string id, CancellationToken ctx);
        bool Existe(string id);
        Task<CampanhaEntity> ObterTodas(CancellationToken ctx);
    }
}
