using EmployerPortal.Models;
using EmployerPortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository empRepository;
        public EmployeeController(EmployeeRepository employeeRepository) 
        {
            this.empRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmployees = await empRepository.GetAllEmployees();
            return Ok(allEmployees);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee vm)
        {
            await empRepository.SaveEmployee(vm);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, [FromBody] Employee vm)
        {
            await empRepository.UpdateEmployee(id, vm);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            await empRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
