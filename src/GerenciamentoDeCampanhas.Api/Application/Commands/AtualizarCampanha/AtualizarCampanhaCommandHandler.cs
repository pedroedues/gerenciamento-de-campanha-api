using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha
{
    public class AtualizarCampanhaCommandHandler : IRequestHandler<AtualizarCampanhaCommand>
    {
        public AtualizarCampanhaCommandHandler()
        {
        }

        public async Task<Unit> Handle(AtualizarCampanhaCommand request, CancellationToken cancellationToken)
        {
			throw new NotImplementedException();
        }
    }
}
