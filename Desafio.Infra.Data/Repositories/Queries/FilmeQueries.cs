namespace Desafio.Infra.Data.Repositories.Queries
{
    public class FilmeQueries
    {
        public static string Inserir = @"Insert into Filme(Titulo, Diretor) Values(@Titulo, @Diretor);
                                        Select SCOPE_IDENTITY();";
        public static string Atualizar = "Update Filme Set Titulo=@Titulo, Diretor=@Diretor Where IdFilme=@Id;";
        public static string Excluir = "Delete from Filme Where IdFilme=@Id;";
        public static string Listar = "Select IdFilme, Titulo as Titulo, Diretor as Diretor From Filme;";
        public static string Obter = "Select IdFilme, Titulo as Titulo, Diretor as Diretor From Filme Where IdFilme=@Id";
        public static string CheckId = "Select IdFilme From Filme Where IdFilme=@Id;";
    }
}
