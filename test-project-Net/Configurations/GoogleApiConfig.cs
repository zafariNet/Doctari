using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace test_project_Net.Configurations
{
    public static class GoogleApiConfig
    {
        public static void ConfigureGeoCode(this IServiceCollection services, IConfiguration configuration)
        {
            var address = configuration.GetSection("GoogleServices:GeoCodeAddress").Value;
            var key = configuration.GetSection("GoogleServices:GeoCodeKey").Value;
            var config = new GoogleApiConfiguration
            {
                ApiAddress = address,
                Key = key
            };
            services.AddSingleton(config);
        }
    }
}
