using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Sprout.Exam.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Sprout.Exam.DataAccess.Data;

namespace Sprout.Exam.DataAccess.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConfiguration _dbConfiguration;
        public EmployeeRepository(IDbConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            using var db = await _dbConfiguration.GetConnectionAsync();
            return await db.QueryAsync<EmployeeEntity>(@"Select * from employees");
        }
        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            using var db = await _dbConfiguration.GetConnectionAsync();
            return await db.QueryFirstOrDefaultAsync<EmployeeEntity>(@"Select * from employees where Id = @Id",new { Id = id });
        }

        public async Task<int> InsertEmployee(EmployeeInput employeeInput)
        {
            using var db = await _dbConfiguration.GetConnectionAsync();
            return await db.ExecuteAsync(@"INSERT INTO Employee (Fullname, Birthdate, TIN, IsDeleted) VALUES (@Fullname, @Birthdate, @TIN, 0)", new { Fullname = employeeInput.FullName, Birthdate = employeeInput.Birthdate, TIN = employeeInput.Tin});
        }
        public async Task<int> DeleteEmployee(int id)
        {
            using var db = await _dbConfiguration.GetConnectionAsync();
            return await db.ExecuteAsync(@"DELETE FROM Employee WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> UpdateEmployee(EmployeeInput employeeInput)
        {
            using var db = await _dbConfiguration.GetConnectionAsync();
            return await db.ExecuteAsync(@"UPDATE Employee SET Fullname = @Fullname, Birthdate = @Birthdate, TIN = @TIN WHERE Id = @Id)", new { Fullname = employeeInput.FullName, Birthdate = employeeInput.Birthdate, TIN = employeeInput.Tin });
        }

    }
}