using System.Data;
using System.Reflection.Metadata;
using MySql.Data.MySqlClient;

namespace BioDataJWT.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)  //injecting the IConfig which is a predefined Interface in dapper which xan be used to acces the connection strings in the appSettings
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection()=> new MySqlConnection(connectionString);
    }
}
