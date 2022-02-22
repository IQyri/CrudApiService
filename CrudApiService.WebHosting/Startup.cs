using CrudApiService.Abstract.Interfaces;
using CrudApiService.Repository;
using CrudApiService.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrudApiService.WebHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen()
                .AddControllers();

            //Db
            services
                //.AddSingleton<DataBaseContext>()
                .AddSingleton( provider => DataGenerator.Initialize())
                .AddSingleton<IProvidedProductRepository>(
                    provider => new ProvidedProductRepository(provider.GetService<DataBaseContext>()))
                .AddSingleton<ISalesPointRepository>( 
                    provider => new SalesPointRepository(provider.GetService<DataBaseContext>()))
                .AddSingleton<ISalesDataRepository>(
                    provider => new SalesDataRepository(provider.GetService<DataBaseContext>()))
                .AddSingleton<IBuyerRepository>(
                    provider => new BuyerRepository(provider.GetService<DataBaseContext>()))
                .AddSingleton<ISalesRepository>(
                    provider => new SalesRepository(provider.GetService<DataBaseContext>()))
                .AddSingleton<IProductRepository>(
                    provider => new ProductRepository(provider.GetService<DataBaseContext>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiTest V1");
                    c.RoutePrefix = string.Empty;
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
