using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Repositories.Implementations;
using CreateEmployeeDto = Sprout.Exam.Business.DataTransferObjects.CreateEmployeeDto;

namespace Sprout.Exam.Business.LogicCollection.Employee
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<double> CalculateRegEmployeeSalary(int id, decimal absentDays, decimal workedDays)
        {
            double regEmployeeMonthlySalary = 25000;
            decimal daysToWork = 22;
            var taxToBeDeducted = .12;
            var perDayDeduction = regEmployeeMonthlySalary / Convert.ToDouble(daysToWork);

            if (absentDays > 0)
            {
                var totalAmountToBeDeducted = Convert.ToDouble(absentDays) * perDayDeduction;
                regEmployeeMonthlySalary = (regEmployeeMonthlySalary - totalAmountToBeDeducted) * taxToBeDeducted;
            }

            var totalSalary = regEmployeeMonthlySalary - (regEmployeeMonthlySalary * taxToBeDeducted);
            return totalSalary;
        }
        public async Task<double> CalculateContractualEmployeeSalary(int id, decimal absentDays, decimal workedDays)
        {
            double regEmployeeMonthlySalary = 20000;
            decimal daysToWork = 22;
            var taxToBeDeducted = .12;
            var perDayDeduction = regEmployeeMonthlySalary / Convert.ToDouble(daysToWork);

            if (absentDays > 0)
            {
                var totalAmountToBeDeducted = Convert.ToDouble(absentDays) * perDayDeduction;
                regEmployeeMonthlySalary = (regEmployeeMonthlySalary - totalAmountToBeDeducted) * taxToBeDeducted;
            }

            var totalSalary = regEmployeeMonthlySalary - (regEmployeeMonthlySalary * taxToBeDeducted);
            return totalSalary;
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeRepository.GetEmployees());
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            return _mapper.Map<EmployeeDto>(await _employeeRepository.GetEmployeeById(id));
        }

        public async Task<int> CreateEmployee(CreateEmployeeDto employee)
        {
            var input = _mapper.Map<EmployeeInput>(employee);
            return await _employeeRepository.InsertEmployee(input);
        }
        
        public async Task<int> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }
        public async Task<int> UpdateEmployee(EditEmployeeDto editEmployee)
        {
            var input = _mapper.Map<EmployeeInput>(editEmployee);
            return await _employeeRepository.UpdateEmployee(input);
        }
    }
}
