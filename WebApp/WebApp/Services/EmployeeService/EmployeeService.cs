using WebApp.DataContext;
using WebApp.Domain.Models;

namespace WebApp.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface


    {
        //Injeção de dependencia
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponds<List<Employee>>> ChangeEmployeeStatus(int id)
        {
            ServiceResponds<List<Employee>> serviceResponds = new ServiceResponds<List<Employee>>();
            try
            {

                Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponds.Data = null;
                    serviceResponds.Message = "User Not Found";
                    serviceResponds.Success = false;
                }

                employee.Status = false;
                employee.ModificationDate = DateTime.Now.ToLocalTime(); // Data da alteração
                _context.Employees.Update(employee); //Manda o funcionario com os dados atualizados
                await _context.SaveChangesAsync();// salva as operações que realizamos

                serviceResponds.Data = _context.Employees.ToList(); // Lista os usuarios com o usuario selecionado atualizado

            }
            catch (Exception ex)
            {
                serviceResponds.Message = ex.Message;
                serviceResponds.Success = false;
            }

            return serviceResponds;
        }

        public async Task<ServiceResponds<List<Employee>>> CreateEmployee(Employee employee)
        {

            ServiceResponds<List<Employee>> serviceResponds = new ServiceResponds<List<Employee>>();

            try
            {
                if (employee == null)
                {

                    serviceResponds.Data = null;
                    serviceResponds.Message = "Type data";
                    serviceResponds.Success = false;
                    return serviceResponds;
                }

                _context.Add(employee); //Adiciona 
                await _context.SaveChangesAsync(); // salva os dados   // colocar await pois é um savechangeASYNC
                serviceResponds.Data = _context.Employees.ToList(); //Retora a lista de todos funcionais com o novo funcionario salvo

            }
            catch (Exception ex)
            {
                serviceResponds.Message = ex.Message;
                serviceResponds.Success = false;
            }

            return serviceResponds;
        }

        public Task<ServiceResponds<List<Employee>>> DeleteEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponds<List<Employee>>> GetAllEmployyes() // async pois colocamos Task<> indicando que é um método assincrono
        {
            ServiceResponds<List<Employee>> serviceResponds = new ServiceResponds<List<Employee>>();

            try
            {
                serviceResponds.Data = _context.Employees.ToList();
                if (serviceResponds.Data.Count == 0)
                {
                    serviceResponds.Message = "No data";
                }

            }
            catch (Exception ex)
            {
                serviceResponds.Message = ex.Message;
                serviceResponds.Success = false;

            }

            return serviceResponds;

        }

        public async Task<ServiceResponds<Employee>> GetEmployeeById(int id)
        {
            ServiceResponds<Employee> serviceResponds = new ServiceResponds<Employee>();

            try
            {
                Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
                if (employee == null)
                {
                    serviceResponds.Data = null;
                    serviceResponds.Message = "User Not Found";
                    serviceResponds.Success = false;
                }
                serviceResponds.Data = employee;

            }
            catch (Exception ex)
            {
                serviceResponds.Message = ex.Message;
                serviceResponds.Success = false;

            }

            return serviceResponds;
        }

        public Task<ServiceResponds<List<Employee>>> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
