namespace Youtube.Service.GraphQL;

public static class DI
{
    public static IServiceCollection AddAppGraphQL(this IServiceCollection services)
    {
        services.AddGraphQLServer();
        return services;
    }
}