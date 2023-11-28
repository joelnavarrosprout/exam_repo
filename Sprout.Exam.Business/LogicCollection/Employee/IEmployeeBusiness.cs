using Sprout.Exam.Business.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.LogicCollection.Employee
{
    public interface IEmployeeBusiness
    {
        Task<double> CalculateRegEmployeeSalary(int id, decimal absentDays, decimal workedDays);
        Task<double> CalculateContractualEmployeeSalary(int id, decimal absentDays, decimal workedDays);
        Task<IEnumerable<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<int> CreateEmployee(CreateEmployeeDto employee);
        Task<int> DeleteEmployee(int id);
        Task<int> UpdateEmployee(EditEmployeeDto editEmployee);
    }
}