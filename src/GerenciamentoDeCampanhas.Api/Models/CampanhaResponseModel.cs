using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;

namespace GerenciamentoDeCampanhas.Api.Models
{
    public class CampanhaResponseModel
    {
        public string Id { get; set; }
        public int MaximoDeCliques { get; set; }
        public string LinkDeAcesso { get; set; }
        public IList<LinkValueObject> Links { get; set; }

        public CampanhaResponseModel(string id, int maximoDeCliques, string linkDeAcesso, IList<LinkValueObject> links)
        {
            Id = id;
            MaximoDeCliques = maximoDeCliques;
            LinkDeAcesso = linkDeAcesso;
            Links = links;
        }
    }
}
