namespace Desafio.Infra.Data.Repositories.Queries
{
    public class VotoQueries
    {
        public static string Inserir = @"Insert into Voto(IdUsuario, IdFilme) Values(@IdUsuario, @IdFilme);
                                        Select SCOPE_IDENTITY()";
        public static string Excluir = "Delete From Voto Where Id=@Id;";
        public static string Listar = @"SELECT v.Id, u.IdUsuario, u.Nome, u.Login, 
                                        f.IdFilme, f.Titulo, f.Diretor FROM Voto v 
                                        INNER JOIN Filme f ON v.IdFilme = f.IdFilme
                                        INNER JOIN Usuario u ON v.IdUsuario = u.IdUsuario;";
        public static string Obter = @"SELECT v.Id, u.IdUsuario, u.Nome, u.Login, 
                                        f.IdFilme, f.Titulo, f.Diretor FROM Voto v 
                                        INNER JOIN Filme f ON v.IdFilme = f.IdFilme
                                        INNER JOIN Usuario u ON v.IdUsuario = u.IdUsuario
                                        Where v.Id=@Id;";
        public static string CheckId = "Select Id as Id From Voto Where Id=@Id;";
    }
}
