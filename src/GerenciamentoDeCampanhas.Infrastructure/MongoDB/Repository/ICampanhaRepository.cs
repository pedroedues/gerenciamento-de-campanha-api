using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;

namespace GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository
{
    public interface ICampanhaRepository
    {
        Task<bool> Inserir(CampanhaEntity campanha, CancellationToken ctx);
        Task<bool> Atualizar(CampanhaEntity campanha, CancellationToken ctx);
        Task<CampanhaEntity> ObterPeloId(string id, CancellationToken ctx);
        Task<IEnumerable<CampanhaEntity>> ObterTodos(CancellationToken ctx);
        Task<CampanhaEntity> ObterPorLinkDeAcesso(string linkDeAcesso, CancellationToken ctx);
        bool ExisteLinkAcesso(string linkDeAcesso);
        bool Existe(string id);
    }
}
