using Desafio.Domain.Entidades;
using Desafio.Domain.Query;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Remover(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
