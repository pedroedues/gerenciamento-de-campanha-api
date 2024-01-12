using GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha;
using GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha;
using GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha;
using GerenciamentoDeCampanhas.Api.Models;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoDeCampanhas.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CampanhaController : ControllerBase
    {
        private readonly ILogger<CampanhaController> _logger;
        private readonly IMediator _mediator;
        private readonly ICampanhaRepository _repository;

        public CampanhaController(ILogger<CampanhaController> logger, IMediator mediator, ICampanhaRepository repository)
        {
            _logger = logger;
            _mediator = mediator;
            _repository = repository;
        }

        /// <summary>
        /// Criação de Campanhas
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(CriarCampanhaCommandResponse))]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> CriarCampanha(
            [FromBody] CriarCampanhaCommand command,
            CancellationToken ctx)
        {
            var response = await _mediator.Send(command, ctx);

            return Created(nameof(CriarCampanha), response);
        }

        /// <summary>
        /// Criação de Campanhas
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> AtualizarCampanha(
            [FromRoute] string id,
            [FromBody] AtualizarCampanhaInputModel model,
            CancellationToken ctx)
        {
            await _mediator.Send(new AtualizarCampanhaCommand(id, model), ctx);

            return NoContent();
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CampanhaResponseModel>))]
        public async Task<ActionResult> OberTodos(
            CancellationToken ctx)
        {
            var campanhasResponse = await _repository.ObterTodos(ctx);

            return Ok(campanhasResponse);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CampanhaResponseModel))]
        public async Task<ActionResult> OberPorId(
            [FromRoute] string id,
            CancellationToken ctx)
        {
            var campanhaEntity = await _repository.ObterPeloId(id, ctx);

            var campanhaResponse = new CampanhaResponseModel(campanhaEntity.Id, campanhaEntity.MaximoDeCliques, campanhaEntity.LinkDeAcesso, campanhaEntity.Links);

            return Ok(campanhaResponse);
        }

        /// <summary>
        /// Criação de Campanhas
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        [HttpPut("Redirecionar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RedirecionamentoCampanhaCommandResponse))]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> RedirecionarCampanha(
            [FromBody] RedirecionamentoCampanhaCommand command,
            CancellationToken ctx)
        {
            var response = await _mediator.Send(command, ctx);

            return Ok(response);
        }
    }
}
