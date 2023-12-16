using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects;

namespace GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities
{
    public class CampanhaEntity : BaseEntity<string>
    {

        public int MaximoDeCliques { get; private set; }

        public string LinkDeAcesso { get; private set; }

        public IList<LinkValueObject> Links { get; private set; }

        public CampanhaEntity()
        {
            
        }

        public CampanhaEntity(int maximoDeCliques)
            : base(Guid.NewGuid().ToString())
        {
            MaximoDeCliques = maximoDeCliques;
            LinkDeAcesso = $"www.DominioCliente.com.br/{Guid.NewGuid()}";
        }

        public void AddLink(string url)
        {
            Links ??= new List<LinkValueObject>();

            Links.Add(new LinkValueObject(url));
        }
        
        public void AddLink(int cliquesRecebidos, string url)
        {
            Links ??= new List<LinkValueObject>();

            Links.Add(new LinkValueObject(cliquesRecebidos, url));
        }

        public void AddLink(IList<string> urls)
        {
            Links ??= new List<LinkValueObject>();

            foreach (var url in urls)
                Links.Add(new LinkValueObject(url));
        }

        public void AddLink(IList<LinkValueObject> links)
        {
            Links ??= new List<LinkValueObject>();

            foreach (var link in links)
                Links.Add(link);
        }

        public void RemoveAllLinks()
            => Links = new List<LinkValueObject>();

        public void SetMaximoDeCliques(int cliques)
            => MaximoDeCliques = cliques;
    }
}
