using Desafio.Domain.Commands.Inputs.Filme;
using Desafio.Domain.Handlers;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Desafio.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("filmes")]
        public List<FilmeQueryResult> Listar()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("filmes/{id}")]
        public FilmeQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpPost]
        [Route("filmes")]
        public ICommandResult Inserir([FromBody] AdicionarFilmeCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("filmes/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("filmes/{id}")]
        public ICommandResult Remover(long id)
        {
            var command = new RemoverFilmeCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
