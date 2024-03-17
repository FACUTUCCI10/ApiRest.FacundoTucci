using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
namespace Api.Persistence.Context
{
    public class ApplicationDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public ApplicationDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("ApiConnection")!;
        }
        public IDbConnection CreateConnection => new SqlConnection(_ConnectionString); //pasamos como parámetro la cadena de conexion/we write the connection string as a parameter
        
    }

}
