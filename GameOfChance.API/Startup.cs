using GameOfChance.Api.Middlewares;
using GameOfChance.Repository.IRepositories;
using GameOfChance.Repository.Repositories;
using GameOfChance.Service.IServices;
using GameOfChance.Service.Services;
using Microsoft.OpenApi.Models;

namespace GameOfChance.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(); services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<Api.SearchFilters.SearchFilters>(); // Inject the applicant filter to assign the default values of specific model
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Players", Version = "v1" });
            });
            // 1. Register the created repositories
            RegisterRepositories(services);
            // 2. Register the created services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the middleware the handle the exception at global level
            app.ConfigureExceptionHandler();

            app.UseRouting();

            //Invoking the cors middleware
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Players v1"));
        }
    }
}
