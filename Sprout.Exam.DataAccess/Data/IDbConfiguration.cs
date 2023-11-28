using System.Data;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Data
{
    public interface IDbConfiguration
    {
        Task<IDbConnection> GetConnectionAsync();
    }
}