using Desafio.Domain.Commands.Inputs.Authentication;
using Desafio.Domain.Handlers;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationHandler _handler;

        public AuthenticationController(AuthenticationHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("login")]
        public ICommandResult Autenticar([FromBody] AuthenticationCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
