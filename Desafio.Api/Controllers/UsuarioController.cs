﻿using Desafio.Domain.Commands.Inputs.Usuario;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/usuarios")]
        public List<UsuarioQueryResult> Listar()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult Inserir([FromBody] AdicionarUsuarioCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/usuarios/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult Remover(long id)
        {
            var command = new RemoverUsuarioCommand() { Id = id };
            var result = _handler.Handle(command);
            return result;
        }
    }
}