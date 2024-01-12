using FluentValidation;
using GerenciamentoDeCampanhas.Domain.AggregatesModel.Entities;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha
{
    public class RedirecionamentoCampanhaCommandValidator : AbstractValidator<RedirecionamentoCampanhaCommand>
    {
        private CampanhaEntity _campanha;
        private ICampanhaRepository _repository;

        public RedirecionamentoCampanhaCommandValidator(ICampanhaRepository repository)
        {
            _repository = repository;

            RuleFor(c => c.LinkDeAcesso)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Link de acesso é obrigatório")
                .MustAsync(async (command, link, ctx) => await ExisteCampanha(link, ctx))
                    .WithMessage("Não foi identificado nenhuma campanha com esse Link de Acesso");
        }

        private async Task<bool> ExisteCampanha(string link, CancellationToken ctx)
        {
            _campanha = await _repository.ObterPorLinkDeAcesso(link, ctx);

            return _campanha is not null;
        }
    }
}
