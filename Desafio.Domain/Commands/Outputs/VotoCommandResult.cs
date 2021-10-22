using Desafio.Infra.Interfaces.Commands;

namespace Desafio.Domain.Commands.Outputs
{
    public class VotoCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public VotoCommandResult(bool sucess, string message, object data)
        {
            Success = sucess;
            Message = message;
            Data = data;
        }
    }
}
