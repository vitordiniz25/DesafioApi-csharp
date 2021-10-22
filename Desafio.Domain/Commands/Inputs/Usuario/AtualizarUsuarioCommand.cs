using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;

namespace Desafio.Domain.Commands.Inputs.Usuario
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "Id inválido");
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                if(Nome.Length > 50)
                    AddNotification("Nome", "Nome não pode possuir mais de 50 caracteres");
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é um campo obrigatório");
                if (Login.Length > 50)
                    AddNotification("Login", "Login não pode possuir mais de 50 caracteres");
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                if (Senha.Length > 50)
                    AddNotification("Senha", "Senha não pode possuir mais de 50 caracteres");
                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
