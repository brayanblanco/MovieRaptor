using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MovieRaptor.Infrastructure.Users
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddUsersContextPool(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<UsersDbSettings>()
                .Configure(options => configuration.GetSection(UsersDbSettings.SectionName).Bind(options))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddDbContextPool<UsersDbContext>((serviceProvider, optionBuilder) =>
            {
                var dbSettings = serviceProvider.GetRequiredService<IOptions<UsersDbSettings>>().Value;
                optionBuilder.UseNpgsql(dbSettings.ConnectionString);
            });

            return services;
        }
        public static IServiceProvider MigrateUsersDb(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
                db.Database.Migrate();
            }

            return services;
        }
    }
}
