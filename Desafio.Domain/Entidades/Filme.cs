namespace Desafio.Domain.Entidades
{
    public class Filme
    {
        public long IdFilme { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(long id, string titulo, string diretor)
        {
            IdFilme = id;
            Titulo = titulo;
            Diretor = diretor;
        }

        public void SetId(long id)
        {
            IdFilme = id;
        }
    }
}
