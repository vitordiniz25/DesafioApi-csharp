using Dapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Data.DataContexts;
using Desafio.Infra.Data.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Desafio.Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parameters.Add("Id", voto.Id, DbType.Int64);
                _parameters.Add("IdUsuario", voto.IdUsuario, DbType.Int64);
                _parameters.Add("IdFilme", voto.IdFilme, DbType.Int64);
                return _dataContext.SqlConnection.ExecuteScalar<long>(VotoQueries.Inserir, _parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Remover(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                _dataContext.SqlConnection.Execute(VotoQueries.Excluir, _parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    VotoQueries.Listar,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario,IdFilme"
                    ).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public VotoQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    VotoQueries.Obter,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario,IdFilme",
                    param: _parameters
                ).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlConnection.Query<bool>(VotoQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
