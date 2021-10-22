using Desafio.Domain.Entidades;
using Desafio.Domain.Query;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme filme);
        void Atualizar(Filme filme);
        void Remover(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
