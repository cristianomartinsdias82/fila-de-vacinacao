using Application.Queries.GetVaccinationQueue.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPriorityByOccupationRulesRepository, PriorityByOccupationRulesRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();

            return services;
        }
    }
}
