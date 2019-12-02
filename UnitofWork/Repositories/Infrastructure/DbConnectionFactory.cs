using System;
using System.Data;
using System.Data.SqlClient;

namespace UnitofWork.Repositories.Infrastructure
{
    public class DbConnectionFactory : IDbConnectionFactory, IDisposable
    {
        private readonly SqlConnection _connection;

        public DbConnectionFactory(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
