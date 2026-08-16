using Microsoft.Extensions.DependencyInjection;

namespace SchoolProject.Core
{
    public static class CoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CoreDependencies).Assembly));
            return services;
        }

    }
}
