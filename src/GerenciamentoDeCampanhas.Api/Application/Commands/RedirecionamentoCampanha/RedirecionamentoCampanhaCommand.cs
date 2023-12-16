using MediatR;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha
{
    public class RedirecionamentoCampanhaCommand : IRequest<RedirecionamentoCampanhaCommandResponse>
    {
        public string LinkDeAcesso { get; set; }

        public RedirecionamentoCampanhaCommand(string linkDeAcesso)
        {
            LinkDeAcesso = linkDeAcesso;
        }
    }
}
