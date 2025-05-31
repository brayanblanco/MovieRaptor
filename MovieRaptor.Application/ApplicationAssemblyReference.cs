using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MovieRaptor.Application
{
    public static class ApplicationAssemblyReference
    {

        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
