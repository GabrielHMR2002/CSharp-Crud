using WebApp.Domain.Models;

namespace WebApp.Services.EmployeeService
{
    public interface IEmployeeInterface
    {
        //Task pois estamos usando metodos assincronos, para que ele espere realizar uma operação no banco antes de prosseguir com
        //o restante do codigo para evitar possiveis erros caso o banco demore responder

        Task<ServiceResponds<List<Employee>>> GetAllEmployyes();
        Task<ServiceResponds<List<Employee>>> CreateEmployee(Employee employee);
        Task<ServiceResponds<Employee>> GetEmployeeById(int id);
        Task<ServiceResponds<List<Employee>>> UpdateEmployee(Employee employee);
        Task<ServiceResponds<List<Employee>>> DeleteEmployeeById(int id);
        Task<ServiceResponds<List<Employee>>> ChangeEmployeeStatus(int id);

    }
}
