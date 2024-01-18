using GerenciamentoDeCampanhas.Api.Controllers;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;
using MediatR;
using System.Text.Json;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha
{
    public class RedirecionamentoCampanhaCommandHandler : IRequestHandler<RedirecionamentoCampanhaCommand, RedirecionamentoCampanhaCommandResponse>
    {
        private readonly ICampanhaRepository _campanhaRepository;
        private readonly ILogger<CampanhaController> _logger;

        public RedirecionamentoCampanhaCommandHandler(ICampanhaRepository campanhaRepository, ILogger<CampanhaController> logger)
        {
            _campanhaRepository = campanhaRepository;
            _logger = logger;
        }

        public async Task<RedirecionamentoCampanhaCommandResponse> Handle(RedirecionamentoCampanhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var campanha = await _campanhaRepository.ObterPorLinkDeAcesso(request.LinkDeAcesso, cancellationToken);
                var chegouLimite = campanha.Links.Any(c => c.CliquesRecebidos < campanha.MaximoDeCliques) is false;
                if (chegouLimite)
                {
                    foreach (var link in campanha.Links)
                        link.ZerarCliques();
                }

                var linkRedirecionamento = ObterLinkDeRedirecionamentoAindaNaoUsado(campanha);

                if (chegouLimite is false)
                    IncrementarCliquesEmLinkSelecionado(campanha, linkRedirecionamento);

                await _campanhaRepository.Atualizar(campanha, cancellationToken);

                var linkAtualizado = campanha.Links.First(l => l.Url.Equals(linkRedirecionamento.Url));

                return new(linkAtualizado.Url, linkAtualizado.CliquesRecebidos, campanha.MaximoDeCliques);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao persistir campanha. Exception {ex.Message}", JsonSerializer.Serialize(request));

                throw;
            }
        }

        private static void IncrementarCliquesEmLinkSelecionado(CampanhaEntity campanha, LinkValueObject linkRedirecionamento)
        {
            campanha
                .Links
                .Where(l => l.Url.Equals(linkRedirecionamento.Url))
                .First()
                .IncrementarCliques();
        }

        private static LinkValueObject ObterLinkDeRedirecionamentoAindaNaoUsado(CampanhaEntity campanha)
        {
            return campanha.Links.First(c => c.CliquesRecebidos < campanha.MaximoDeCliques);
        }
    }
}
