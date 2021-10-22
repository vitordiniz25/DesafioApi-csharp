using Desafio.Domain.Commands.Inputs.Voto;
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
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/votos")]
        public List<VotoQueryResult> Listar()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/votos/{id}")]
        public VotoQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpPost]
        [Route("v1/votos")]
        public ICommandResult Inserir([FromBody] AdicionarVotoCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/votos/{id}")]
        public ICommandResult Remover(long id)
        {
            var command = new ExcluirVotoCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}
