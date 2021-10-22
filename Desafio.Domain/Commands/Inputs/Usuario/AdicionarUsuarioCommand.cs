using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Commands.Inputs.Usuario
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é um campo obrigatório.");
                if (Login.Length > 50)
                    AddNotification("Login", "Login não pode ter mais de 15 caracteres");
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                if (Nome.Length > 50)
                    AddNotification("Nome", "Nome não pode ter mais de 15 caracteres");
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                if (Senha.Length > 50)
                    AddNotification("Senha", "Senha não pode ter mais de 15 caracteres");

                return Valid;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
