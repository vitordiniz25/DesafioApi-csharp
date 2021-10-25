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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parameters = new();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public long Inserir(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.IdUsuario, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);
                return _dataContext.SqlConnection.ExecuteScalar<long>(UsuarioQueries.Inserir, _parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.IdUsuario, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);
                _dataContext.SqlConnection.Execute(UsuarioQueries.Atualizar, _parameters);
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
                _dataContext.SqlConnection.Execute(UsuarioQueries.Excluir, _parameters);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlConnection.Query<UsuarioQueryResult>(UsuarioQueries.Listar).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);
                return _dataContext.SqlConnection.Query<UsuarioQueryResult>(UsuarioQueries.Obter, _parameters).FirstOrDefault();
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
                return _dataContext.SqlConnection.Query<bool>(UsuarioQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Autenticar(string login, string senha)
        {
            try
            {
                _parameters.Add("Login", login, DbType.String);
                _parameters.Add("Senha", senha, DbType.String);
                return _dataContext.SqlConnection.Query<bool>(UsuarioQueries.Autenticar, _parameters).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
