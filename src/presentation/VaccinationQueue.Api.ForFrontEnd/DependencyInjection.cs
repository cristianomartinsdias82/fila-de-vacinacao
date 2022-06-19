using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace VaccinationQueue.Api.ForFrontEnd
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddResources(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new JsonFormatPeopleData(GetEmbeddedResourceContent("VaccinationQueue.Api.ForFrontEnd.Data.people.json")));

            return services;
        }

        private static string GetEmbeddedResourceContent(string resourcePath)
        {
            var assemblyStream = Assembly.GetEntryAssembly().GetManifestResourceStream(resourcePath);
            using var reader = new StreamReader(assemblyStream);
            var content = reader.ReadToEnd();
            assemblyStream.Close();

            return content;
        }
    }
}
