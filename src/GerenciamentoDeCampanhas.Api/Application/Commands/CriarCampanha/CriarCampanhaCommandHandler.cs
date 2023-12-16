using GerenciamentoDeCampanhas.Api.Controllers;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;
using MediatR;
using System.Text.Json;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommandHandler : IRequestHandler<CriarCampanhaCommand, CriarCampanhaCommandResponse>
    {
        private readonly ICampanhaRepository _campanhaRepository;
        private readonly ILogger<CampanhaController> _logger;

        public CriarCampanhaCommandHandler(ICampanhaRepository campanhaRepository, ILogger<CampanhaController> logger)
        {
            _campanhaRepository = campanhaRepository;
            _logger = logger;
        }

        public async Task<CriarCampanhaCommandResponse> Handle(CriarCampanhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var campanha = new CampanhaEntity(request.MaximoDeCliques);

                campanha.AddLink(request.Links);

                await _campanhaRepository.Inserir(campanha, cancellationToken);

                return new(campanha.Id, campanha.LinkDeAcesso);
            } catch(Exception ex)
            {
                _logger.LogError($"Erro ao persistir campanha. Exception {ex.Message}", JsonSerializer.Serialize(request));

                throw;
            }
        }
    }
}
