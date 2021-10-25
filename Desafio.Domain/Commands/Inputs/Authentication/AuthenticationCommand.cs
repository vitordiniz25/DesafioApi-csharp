using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Commands.Inputs.Authentication
{
    public class AuthenticationCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é um campo obrigatório!");
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                return Valid;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
