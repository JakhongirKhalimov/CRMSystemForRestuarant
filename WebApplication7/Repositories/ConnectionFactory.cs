
using RestuarantCRM.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace RestuarantCRM.Repositories
{
    public class ConnectionFactory : IConnectionFactory1
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
