using Microsoft.Extensions.DependencyInjection;
using test_project_Net.ExternalWebServices.Concatenates;
using test_project_Net.ExternalWebServices.Interfaces;
using test_project_Net.Repositories.Concatenates;
using test_project_Net.Repositories.Interfaces;
using test_project_Net.Services.Concatenates;
using test_project_Net.Services.Interfaces;

namespace test_project_Net.Configurations
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IGoogleService, GoogleService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IStateService, StateService>();
        }
    }
}
