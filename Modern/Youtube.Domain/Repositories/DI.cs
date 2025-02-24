using Microsoft.Extensions.DependencyInjection;

namespace Youtube.Domain.Repositories;

public static class DI
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<FacultyRepository>();
        return services;
    }
}