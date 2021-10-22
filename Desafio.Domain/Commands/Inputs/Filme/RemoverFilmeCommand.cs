using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;

namespace Desafio.Domain.Commands.Inputs.Filme
{
    public class RemoverFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "Id inválido");

                return Valid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
