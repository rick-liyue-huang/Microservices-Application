using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // todo: add services to the Ioc container
        // infrastructure services often include data access, caching and other low level component

        return services;
    }
}
