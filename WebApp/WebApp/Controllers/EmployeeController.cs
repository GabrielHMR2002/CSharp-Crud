using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Domain.Models;
using WebApp.Services.EmployeeService;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        //Injeção de dependencia
        private readonly IEmployeeInterface _employeeInterface; // 
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees() //ActionResult é o resultado da ação/operação, ex: 400 BadRequest
        {
            return Ok(await _employeeInterface.GetAllEmployyes());// Usar await visto que é um metodo async
        }

        [HttpGet("{id}")]   //diferenciar as rotas pois nesse pegamos o id
        public async Task<ActionResult<ServiceResponds<Employee>>> GetEmployeeById(int id)
        {
            ServiceResponds<Employee> serviceResponds = await _employeeInterface.GetEmployeeById(id);

            return Ok(serviceResponds);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            return Ok(await _employeeInterface.CreateEmployee(employee)); //Não esquecer do await
        }

        [HttpPut("ChangeEmployeeStatus")]
        public async Task<ActionResult<List<Employee>>> ChangeEmployeeStatus(int id)
        {
            ServiceResponds<List<Employee>> serviceResponds = await _employeeInterface.ChangeEmployeeStatus(id); // nao esquecer do await
            return Ok(serviceResponds);
        }
    }
}
