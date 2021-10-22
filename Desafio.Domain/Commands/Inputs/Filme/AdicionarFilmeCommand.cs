using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Commands.Inputs.Filme
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo{ get; set; }
        public string Diretor{ get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Titulo))
                    AddNotification("Titulo", "Titulo é um campo obrigatório");
                if (Titulo.Length > 50)
                    AddNotification("Titulo", "Titulo não pode ter mais de 50 caracteres");
                if (string.IsNullOrEmpty(Diretor))
                    AddNotification("Diretor", "Diretor é um campo obrigatório");
                if (Titulo.Length > 50)
                    AddNotification("Diretor", "Diretor não pode ter mais de 50 caracteres");

                return Valid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
