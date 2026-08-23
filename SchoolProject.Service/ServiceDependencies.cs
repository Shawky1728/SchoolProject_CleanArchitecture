using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstract;
using SchoolProject.Service.Services;

namespace SchoolProject.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }

    }
}
