using Microsoft.Extensions.DependencyInjection;
using PersonApi.Data.Contexts;
using PersonApi.Business.InterfFace;
using PersonApi.Business.Repository;


namespace PersonApi.Api.Extensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<PersonApiContext>();
            services.AddScoped<IPerson, PersonRepository>();
            services.AddScoped<IPAddress, PAddressRepository>();
            return services;
        }
    }
}
