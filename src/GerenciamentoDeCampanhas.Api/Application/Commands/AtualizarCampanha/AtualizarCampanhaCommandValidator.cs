using FluentValidation;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha
{
    public class AtualizarCampanhaCommandValidator : AbstractValidator<AtualizarCampanhaCommand>
    {
        public AtualizarCampanhaCommandValidator(ICampanhaRepository repository)
        {
            RuleFor(c => c.Campanha.Links)
                .Must(links => ContemUrlEmBranco(links) is false)
                    .WithMessage("Nenhum link da campanha pode estar vazio")
                .Must(links => NaoExisteLinkDuplicado(links.Select(links => links.Url).ToList()))
                    .WithMessage("Não pode haver urls duplicadas");

            RuleFor(c => c.Campanha.Links.Count)
                .GreaterThanOrEqualTo(1)
                    .WithMessage("É preciso ter, ao menos, um link para cadastro da campanha");

            RuleFor(c => c.Campanha.MaximoDeCliques)
                .GreaterThanOrEqualTo(1)
                    .WithMessage("O mínimo de cliques aceito por campanha é 1");

            RuleFor(c => c.Id)
                .NotEmpty()
                    .WithMessage("Id é obrigatório")
                .Must(repository.Existe)
                    .WithMessage("Não foi identificado nenhuma campanha com esse Id");
        }

        private static bool ContemUrlEmBranco(IList<LinkInputModel> links)
            => links.Select(l => l.Url).Any(string.IsNullOrWhiteSpace);

        private static bool NaoExisteLinkDuplicado(IList<string> links)
            => links.Count == links.Distinct().Count();
    }
}
