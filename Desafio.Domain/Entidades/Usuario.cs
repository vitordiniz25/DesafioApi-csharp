namespace Desafio.Domain.Entidades
{
    public class Usuario
    {
        public long IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public Usuario(long id, string nome, string login, string senha)
        {
            IdUsuario = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public void SetId(long id)
        {
            IdUsuario = id;
        }
    }
}
