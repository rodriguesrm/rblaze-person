using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBlaze.Person.Domain.Repositories.Persons;
using RBlaze.Person.Infrastructure.Databases;
using RBlaze.Person.Infrastructure.Repositories.Persons;

namespace RBlaze.Person.Infrastructure.Extensions
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure
        (
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName,
            bool useLazyLoadingProxy
        )
        {

            services.AddDbContext<PersonDbContext>(opt =>
            {
                opt.UseMySql
                (
                    configuration.GetConnectionString(connectionStringName),
                    ServerVersion.AutoDetect(configuration.GetConnectionString(connectionStringName))
                );
                if (useLazyLoadingProxy)
                    opt.UseLazyLoadingProxies();
            });

            // Repositories
            services.AddScoped<IAddUpdPersonRepository, PersonRepository>();
            services.AddScoped<IGetPersonRepository, PersonRepository>();
            services.AddScoped<IDeletePersonRepository, PersonRepository>();

            return services;
        }

    }
}
