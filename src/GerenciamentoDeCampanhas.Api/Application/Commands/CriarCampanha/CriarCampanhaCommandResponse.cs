namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommandResponse
    {
        public string Id { get; set; }

        public string LinkDeAcesso { get; set; }

        public CriarCampanhaCommandResponse(string id, string linkDeAcesso)
        {
            Id = id;
            LinkDeAcesso = linkDeAcesso;
        }
    }
}
