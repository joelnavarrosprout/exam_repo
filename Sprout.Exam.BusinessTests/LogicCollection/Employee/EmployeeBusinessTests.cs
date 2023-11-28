using Sprout.Exam.Business.LogicCollection.Employee;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Data;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Implementations;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Sprout.Exam.Business.LogicCollection.Employee.Tests
{

    [TestClass()]
    public class EmployeeBusinessTests
    {
        private IEmployeeRepository _employeeRepository;
        private IDbConfiguration _dbConfiguration;
        private IMapper _mapper;

        [SetUp]

        public void Initialize(IEmployeeRepository employeeRepository, IDbConfiguration dbConfiguration, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _dbConfiguration = dbConfiguration;
            _mapper = mapper;
        }


        [TestMethod()]
        public void CalculateContractualEmployeeSalaryTest()
        {
            //arrange
            int id = 1;
            decimal absentDays = 0;
            decimal workedDays = 22;
            double totalSalary = 17600;

            //act
            var test = new EmployeeBusiness(_employeeRepository, _mapper);
            var salary = test.CalculateContractualEmployeeSalary(id, absentDays, workedDays);

            //assert
            Assert.AreEqual(salary.Result, totalSalary);
        }

        [TestMethod()]
        public void CalculateRegularEmployeeSalaryTest()
        {
            //arrange
            int id = 1;
            decimal absentDays = 0;
            decimal workedDays = 22;
            double totalSalary = 22000;

            //act
            var test = new EmployeeBusiness(_employeeRepository, _mapper);
            var salary = test.CalculateRegEmployeeSalary(id, absentDays, workedDays);

            //assert
            Assert.AreEqual(salary.Result, totalSalary);
        }

        [TestMethod()]
        public void GetEmployeesTest()
        {
            //arrange
            var employeeBusiness = new EmployeeBusiness(_employeeRepository, _mapper);

            var result = employeeBusiness.GetEmployees();

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetEmployeeByIdTest()
        {
            //arrange
            int id = 1;

            var employeeBusiness = new EmployeeBusiness(_employeeRepository, _mapper);

            var result = employeeBusiness.GetEmployeeById(id);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateEmployeeTest()
        {
            var employeeBusiness = new EmployeeBusiness(_employeeRepository, _mapper);
            var result = employeeBusiness.CreateEmployee(new CreateEmployeeDto()
            {
                Birthdate = Convert.ToDateTime("10/10/2001"),
                FullName = "John Doe",
                Tin = "12345",
                TypeId = 1
            });
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            int id = 1;
            var employeeBusiness = new EmployeeBusiness(_employeeRepository, _mapper);
            var result = employeeBusiness.DeleteEmployee(id);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void UpdateEmployeeTest()
        {
            var editEmployee = new EditEmployeeDto
            {
                Birthdate = Convert.ToDateTime("10/10/2001"),
                FullName = "John Doe",
                Id = 1,
                Tin = "12345",
                TypeId = 1
            };

            var employeeBusiness = new EmployeeBusiness(_employeeRepository, _mapper);
            var result = employeeBusiness.UpdateEmployee(editEmployee);
            Assert.IsNotNull(result);
        }
    }
}