
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.DataContext;
using WebApp.Services.EmployeeService;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // builder.Services.AddEntityFrameworkNpgsql().
            //  AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("" +
            //"Host=localhost;Port=5432;Pooling=true;Database=crud;User Id=postgres;Password=2002")); // instalar o postgree

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //IEmployeeInterface se referencia a classe EmployeeService
            //Quando eu fizer uma injeção de dependencia da interface IEmployeeInterface eu quero que seja utilizado os metodos que estao na IEmployeeService
            builder.Services.AddScoped<IEmployeeInterface, EmployeeService>(); //IEmployeeInterface se comunica com o EmployeeService


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();




            app.MapControllers();

            app.Run();
        }
    }
}
