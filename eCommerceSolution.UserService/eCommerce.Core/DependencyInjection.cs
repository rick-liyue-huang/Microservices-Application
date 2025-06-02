using Microsoft.Extensions.DependencyInjection;
using UserService.eCommerce.Core.ServiceContract;
using UserService.eCommerce.Core.Services;


namespace UserService.eCommerce.Core
{
    // extension method to add infrastructure services to the dependency injection container
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // todo : add services to the IoC container
            // Core services often include data access, caching and other low-level components

            services.AddTransient<IUserService, UsersService>();

            return services;
        }

    }
}
