using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataBaseConfig(configuration)
            .AddRegistration();

        return services;
    }


    private static IServiceCollection AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
        {
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }


    private static IServiceCollection AddRegistration(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

}
