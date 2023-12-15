using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommandHandler : IRequestHandler<CriarCampanhaCommand>
    {
        public CriarCampanhaCommandHandler()
        {
        }

        public async Task<Unit> Handle(CriarCampanhaCommand request, CancellationToken cancellationToken)
        {
			throw new NotImplementedException();
        }
    }
}
