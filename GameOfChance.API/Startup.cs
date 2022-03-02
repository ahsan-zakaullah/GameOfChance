using GameOfChance.Api.Filters;
using GameOfChance.Api.Middlewares;
using GameOfChance.API.Extensions;
using GameOfChance.Repository.DbContexts.PlayerDbContext;
using GameOfChance.Repository.IRepositories;
using GameOfChance.Repository.Repositories;
using GameOfChance.Service.IServices;
using GameOfChance.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GameOfChance.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            // JWT Token Generation from Server Side.  
            services.AddMvc();
            // Enable Swagger   
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SearchFilters>(); // Inject the request filter to assign the default values of specific model

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Players", Version = "v1" });
                // To Enable authorization using Swagger (JWT)  
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme." +
                    " \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddSingleton(_configuration);
            services.AddDatabase(_configuration);
            services.AddIdentityAndJWT(_configuration);
            services.AddCors("GameOfChance");
            // 1. Register the created repositories
            RegisterRepositories(services);
            // 2. Register the created services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddTransient<IStartupFilter, MigrationStartupFilter<IPlayerDbContext>>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IUserAndRoleRepository, UserAndRoleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            var db = serviceProvider.GetRequiredService<IPlayerDbContext>();
            // Check is any migration is pending to make impact on database
            if (db != null && db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }

            db?.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the middleware the handle the exception at global level
            app.ConfigureExceptionHandler();


            app.UseCors();
            app.UseRouting();
            // Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Players v1"));
        }
    }
    //public class MigrationStartupFilter<TContext> : IStartupFilter where TContext : IPlayerDbContext
    //{
    //    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    //    {
    //        return app =>
    //        {
    //            using (var scope = app.ApplicationServices.CreateScope())
    //            {
    //                foreach (var context in scope.ServiceProvider.GetServices<TContext>())
    //                {
    //                    context.Database.SetCommandTimeout(160);
    //                    context.Database.Migrate();
    //                }
    //            }
    //            next(app);
    //        };
    //    }
    //}
}
