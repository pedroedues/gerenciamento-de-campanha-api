using GerenciamentoDeCampanhas.Api.Controllers;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;
using MediatR;
using System.Text.Json;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha
{
    public class AtualizarCampanhaCommandHandler : IRequestHandler<AtualizarCampanhaCommand, bool>
    {
        private readonly ICampanhaRepository _campanhaRepository;
        private readonly ILogger<CampanhaController> _logger;

        public AtualizarCampanhaCommandHandler(ICampanhaRepository campanhaRepository, ILogger<CampanhaController> logger)
        {
            _campanhaRepository = campanhaRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(AtualizarCampanhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var campanha = await _campanhaRepository.ObterPeloId(request.Id, cancellationToken);

                campanha.SetMaximoDeCliques(request.Campanha.MaximoDeCliques);
                campanha.RemoveAllLinks();

                AtualizarLinks(request, campanha);

                await _campanhaRepository.Atualizar(campanha, cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar campanha. Exception {ex.Message}", JsonSerializer.Serialize(request));

                throw;
            }
        }

        private static void AtualizarLinks(AtualizarCampanhaCommand request, CampanhaEntity campanha)
        {
            foreach (var link in request.Campanha.Links)
                campanha.AddLink(link.QuantidadeCliques, link.Url);
        }
    }
}
