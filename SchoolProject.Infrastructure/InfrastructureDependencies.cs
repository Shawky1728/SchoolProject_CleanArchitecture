using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Infrastructure.Abstract.Procedures;
using SchoolProject.Infrastructure.Abstract.Views;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.GenericRepository;
using SchoolProject.Infrastructure.Repositories;
using SchoolProject.Infrastructure.Repositories.Procedures;
using SchoolProject.Infrastructure.Repositories.Views;

namespace SchoolProject.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IViewRepository, ViewRepository>();
            services.AddScoped<IProcedures, ProceduresRepository>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }
    }
}
