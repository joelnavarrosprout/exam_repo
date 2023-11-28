using System.Collections.Generic;
using System.Threading.Tasks;
using Sprout.Exam.DataAccess.Entities;

namespace Sprout.Exam.DataAccess.Repositories.Implementations
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<int> InsertEmployee(EmployeeInput employeeInput);
        Task<int> DeleteEmployee(int id);
        Task<int> UpdateEmployee(EmployeeInput employeeInput);
    }
}