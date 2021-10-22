namespace Desafio.Domain.Query
{
    public class VotoQueryResult
    {
        public long Id { get; set; }
        public UsuarioQueryResult Usuario { get; set; }
        public FilmeQueryResult Filme { get; set; }
    }
}
