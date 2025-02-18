using Domain.Arls;
using Domain.Employees;
using Domain.Epss;
using Domain.Pensions;
using HR_Platform.Application.Data;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistance();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer());

        services.AddScoped<IApplicationDBContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPensionRepository, PensionRepository>();
        services.AddScoped<IArlRepository, ArlRepository>();
        services.AddScoped<IEpsRepository, EpsRepository>();

        return services;
    }
}
