using FluentValidation;

namespace GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha
{
    public class CriarCampanhaCommandValidator : AbstractValidator<CriarCampanhaCommand>
    {
        public CriarCampanhaCommandValidator()
        {
            RuleFor(c => c.Links)
                .Must(links => links.Any(string.IsNullOrWhiteSpace)  is false)
                    .WithMessage("Nenhum link da campanha pode estar vazio")
                .Must(NaoExisteLinkDuplicado)
                    .WithMessage("Não pode haver urls duplicadas");

            RuleFor(c => c.Links.Count)
                .GreaterThanOrEqualTo(1)
                .WithMessage("É preciso ter, ao menos, um link para cadastro da campanha");

            RuleFor(c => c.MaximoDeCliques)
                .GreaterThanOrEqualTo(1)
                .WithMessage("O mínimo de cliques aceito por campanha é 1");
        }

        private static bool NaoExisteLinkDuplicado(IList<string> links)
            => links.Count == links.Distinct().Count();
    }
}
