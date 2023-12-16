using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;
using MediatR;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommand : IRequest<CriarCampanhaCommandResponse>
    {
        public int MaximoDeCliques { get; set; }

        public IList<string> Links { get; set; }
    }
}
