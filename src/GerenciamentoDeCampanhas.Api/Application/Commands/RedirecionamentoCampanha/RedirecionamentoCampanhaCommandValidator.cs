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
                    .WithMessage("Não foi identificado nenhuma campanha com esse Link de Acesso")
                .Must(c => AindaPossuiLinkDisponivel())
                    .WithMessage("A campanha existe, porém, não possui mais nenhum link disponível, todas Url's chegaram ao máximo de cliques disponíveis na campanha. " +
                                "Para resolver, atualize a campanha para um maior número de Cliques, ou, adcione mais Url's à ela");
        }

        private bool AindaPossuiLinkDisponivel()
        {
            return _campanha.Links.Where(c => c.CliquesRecebidos < _campanha.MaximoDeCliques).ToList().Count is not 0;
        }

        private async Task<bool> ExisteCampanha(string link, CancellationToken ctx)
        {
            _campanha = await _repository.ObterPorLinkDeAcesso(link, ctx);

            return _campanha is not null;
        }
    }
}
