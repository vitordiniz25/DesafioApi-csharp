using Desafio.Infra.Interfaces.Commands;

namespace Desafio.Domain.Commands.Outputs
{
    public class AuthenticationCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AuthenticationCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
