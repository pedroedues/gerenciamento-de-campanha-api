namespace GerenciamentoDeCampanhas.Domain.AggregatesModel.ValueObjects
{
    public class LinkValueObject
    {
        public int CliquesRecebidos { get; private set; }

        public string Url { get; private set; }

        public LinkValueObject(string url)
        {
            CliquesRecebidos = 0;
            Url = url;
        }

        public LinkValueObject(int cliquesRecebidos, string url)
        {
            CliquesRecebidos = cliquesRecebidos;
            Url = url;
        }

        public void IncrementarCliques(int cliquesRecebidos = 1)
            => CliquesRecebidos += cliquesRecebidos;
    }
}
