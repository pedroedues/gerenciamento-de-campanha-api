namespace GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha
{
    public class RedirecionamentoCampanhaCommandResponse
    {
        public string LinkRedirecionamentoAtual { get; set; }
        public int CliquesRecebidosLinkAtual { get; set; }
        public int MaximoDeCliques { get; set; }

        public RedirecionamentoCampanhaCommandResponse(string linkRedirecionamentoAtual, int cliquesRecebidosLinkAtual, int maximoDeCliques)
        {
            LinkRedirecionamentoAtual = linkRedirecionamentoAtual;
            CliquesRecebidosLinkAtual = cliquesRecebidosLinkAtual;
            MaximoDeCliques = maximoDeCliques;
        }
    }
}
