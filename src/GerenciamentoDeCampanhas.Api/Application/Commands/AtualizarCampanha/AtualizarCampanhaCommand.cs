using GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;
using MediatR;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha
{
    public class AtualizarCampanhaCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public AtualizarCampanhaInputModel Campanha { get; set; }

        public AtualizarCampanhaCommand(string id, AtualizarCampanhaInputModel campanha)
        {
            Id = id;
            Campanha = campanha;
        }
    }
}
