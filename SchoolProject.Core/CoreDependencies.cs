using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class CoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // add mediatR services from the current assembly
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CoreDependencies).Assembly);
            });

            // register Mapster
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetAssembly(typeof(CoreDependencies)));
            services.AddSingleton<IMapper>(new Mapper(config));

            // register validators from the current assembly
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CoreDependencies)));

            return services;
        }

    }
}
