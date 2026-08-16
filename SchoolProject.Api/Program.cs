
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service;

namespace SchoolProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add Connection String
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region Dependency Injection

            // Add Infrastructure Dependencies
            builder.Services.AddInfrastructureDependencies();

            // Add Service Dependencies
            builder.Services.AddServiceDependencies();

            // Add Core Dependencies
            builder.Services.AddCoreDependencies();

            #endregion

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
