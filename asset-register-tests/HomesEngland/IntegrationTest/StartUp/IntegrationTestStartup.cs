using System;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Interface;
using asset_register_api.Interface.UseCase;
using asset_register_tests.HomesEngland.Mocks;
using hear_api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asset_register_tests.HomesEngland.IntegrationTest.StartUp
{
    public class IntegrationTestStartup
    {
        public IntegrationTestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IAssetGateway, PopulatedInMemoryAssetGateway>();
            services.AddTransient<IGetAssetUseCase, GetAsset>();
            services.AddTransient<IGetAssetsUseCase, GetAssets>();
           
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = "Development";
            app.UseMvc();
        }
    }
}