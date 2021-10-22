using Desafio.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Desafio.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlConnection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                SqlConnection = new SqlConnection(appSettings.ConnectionString);
                SqlConnection.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (SqlConnection.State != ConnectionState.Closed)
                    SqlConnection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
