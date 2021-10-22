using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System.Text.Json.Serialization;

namespace Desafio.Domain.Commands.Inputs.Usuario
{
    public class RemoverUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public bool ValidarCommand()
        {
            if (Id < 0)
                AddNotification("Id", "Id inválido");

            return Valid;
        }
    }
}
