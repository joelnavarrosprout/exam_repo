using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sprout.Exam.DataAccess.Data
{
    public class DbConfiguration : IDbConfiguration
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public DbConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDbConnection> GetConnectionAsync()
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                return new SqlConnection(_connectionString);
            }

            _connectionString = string.Format(_configuration.GetConnectionString("ConnectionStrings"));

            return new SqlConnection(_connectionString);
        }
    }
}