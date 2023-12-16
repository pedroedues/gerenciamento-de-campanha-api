using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha
{
    public class AtualizarCampanhaInputModel
    {
        public int MaximoDeCliques { get; set; }

        public IList<LinkInputModel> Links { get; set; }
    }

    public class LinkInputModel
    {
        public int QuantidadeCliques { get; set; }

        public string Url { get; set; }
    }
}
