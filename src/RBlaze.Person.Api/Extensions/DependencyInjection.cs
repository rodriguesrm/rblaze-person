using RBlaze.Person.Infrastructure.Extensions;

namespace RBlaze.Person.Api.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersonServices
        (
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName,
            bool useLazyLoadingProxy
        )
        {

            services.AddInfrastructure(configuration, connectionStringName, useLazyLoadingProxy);

            return services;

        }

    }
}
