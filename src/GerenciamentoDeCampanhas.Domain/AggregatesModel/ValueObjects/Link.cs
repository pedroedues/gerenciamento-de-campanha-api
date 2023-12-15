namespace GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects
{
    public class Link
    {
        public int CliquesRecebidos { get; private set; }

        public string Url { get; private set; }

        public Link(int cliquesRecebidos, string url)
        {
            CliquesRecebidos = cliquesRecebidos;
            Url = url;
        }
    }
}
