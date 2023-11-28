using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.LogicCollection.Employee;
using Sprout.Exam.Common.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        /// api/employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Task.FromResult(_employeeBusiness.GetEmployees());
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Task.FromResult(_employeeBusiness.GetEmployeeById(id));
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var item = await Task.FromResult(_employeeBusiness.UpdateEmployee(input));
            return Ok(item);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var id = await Task.FromResult(_employeeBusiness.CreateEmployee(input));
            return Created($"/api/employees/{id}", id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Task.FromResult(_employeeBusiness.DeleteEmployee(id));
            if (result == null) return NotFound();
            return Ok(id);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(int id, decimal absentDays, decimal workedDays)
        {
            var result = await Task.FromResult(_employeeBusiness.GetEmployeeById(id));
            
            if (result == null) return NotFound();
            var type = (EmployeeType) result.Result.TypeId;
            
            return type switch
            {
                EmployeeType.Regular =>
                    //create computation for regular.
                    Ok(await _employeeBusiness.CalculateRegEmployeeSalary(id, absentDays, workedDays)),
                EmployeeType.Contractual =>
                    //create computation for contractual.
                    Ok(await _employeeBusiness.CalculateContractualEmployeeSalary(id, absentDays, workedDays)),
                _ => NotFound("Employee Type not found")
            };

        }

    }
}
