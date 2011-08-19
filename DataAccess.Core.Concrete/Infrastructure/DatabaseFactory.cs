using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Core.Abstract;

namespace DataAccess.Core.Concrete.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IDbConnection _dbConnection;

        public IDbConnection DbConnection
        {
            get 
            { 
                if (_dbConnection == null)
                    _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

                return _dbConnection;
            }
        }
    }
}
