using Core.Interfaces;
using Core.Servicess;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;    
    }
}
