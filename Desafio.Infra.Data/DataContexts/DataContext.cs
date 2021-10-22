using Desafio.Infra.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Desafio.Infra.Data.DataContexts
{
    public class DataContext : IDisposable
    {
        public MySqlConnection MySqlConnection { get; set; }

        public DataContext(AppSettings appSettings)
        {
            try
            {
                MySqlConnection = new MySqlConnection(appSettings.ConnectionString);
                MySqlConnection.Open();
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
                if (MySqlConnection.State != ConnectionState.Closed)
                    MySqlConnection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
