using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using test_project_Net.Configurations;
using test_project_Net.Pages;
using test_project_Net.Services;

namespace test_project_Net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.ConfigureGeoCode(Configuration);
            services.ConfigureServices();
            
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<string> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                await next();
                logger.LogInformation($"Calling service take : {stopWatch.Elapsed.Milliseconds} Milliseconds");
            });
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}
