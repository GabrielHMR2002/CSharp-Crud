using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Models;

namespace WebApp.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        //                                            Nome do DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; } //Qual modelo queremos transformar em uma tabela




    }
}
