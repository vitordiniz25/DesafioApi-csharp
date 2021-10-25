using Desafio.Domain.Entidades;
using Desafio.Domain.Query;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);
        bool Autenticar(string login, string senha);
    }
}
