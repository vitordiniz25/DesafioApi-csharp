namespace Desafio.Infra.Data.Repositories.Queries
{
    public class UsuarioQueries
    {
        public static string Inserir = @"Insert into Usuario(Nome, Login, Senha) Values(@Nome, @Login, @Senha);
                                        Select SCOPE_IDENTITY();";
        public static string Atualizar = "Update Usuario Set Nome=@Nome, Login=@Login, Senha=@Senha where IdUsuario=@Id;";
        public static string Excluir = "Delete from Usuario Where IdUsuario=@Id;";
        public static string Listar = "Select IdUsuario, Nome as Nome, Login as Login From Usuario;";
        public static string Obter = "Select IdUsuario, Nome as Nome, Login as Login From Usuario Where IdUsuario=@Id;";
        public static string CheckId = "Select IdUsuario From Usuario Where IdUsuario=@Id;";
        public static string Autenticar = "Select IdUsuario From Usuario Where Login=@Login AND Senha=@Senha";
    }
}
