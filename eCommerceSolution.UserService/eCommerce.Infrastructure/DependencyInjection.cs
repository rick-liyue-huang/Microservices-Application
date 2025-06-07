using UserService.eCommerce.Infrastructure.DbContext;
using Microsoft.Extensions.DependencyInjection;
using UserService.eCommerce.Core.RepositoryContract;
using UserService.eCommerce.Infrastructure.Repositories;


namespace UserService.eCommerce.Infrastructure
{
    // extension method to add infrastructure services to the dependency injection container
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // todo : add services to the IoC container
            // Infrastructure services often include data access, caching and other low-level components

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<DapperDbContext>();

            return services;
        }

    }
}
