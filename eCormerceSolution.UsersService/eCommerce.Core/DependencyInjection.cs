using eCommerce.Core.ServicesContracts;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.Services;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // todo: add services to the Ioc container
        // Core services often include data access, caching and other low level component

        services.AddTransient<IUsersService, UsersService>();

        return services;
    }
}
