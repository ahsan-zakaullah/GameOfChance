using GameOfChance.API.Configuration;
using GameOfChance.Repository.DbContexts.PlayerDbContext;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GameOfChance.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var getSection = (string name) => configuration.GetSection($"Databases:GameOfChance:{name}").Value;
            var databaseInfoGameOfChance = new DatabaseInfo(
                host: getSection("Host"),
                username: getSection("UserName"),
                password: getSection("Password"),
                database: getSection("DatabaseName")
            );
            var migrationsAssembly = typeof(IPlayerDbContext).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<IPlayerDbContext, PlayerDbContext>(
                builder => builder.UseSqlServer(databaseInfoGameOfChance.ConnectionString, optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(migrationsAssembly);
                    optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                }));

        }

        public static void AddIdentityAndJWT(this IServiceCollection services, IConfiguration configuration)
        {
            // For Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PlayerDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }
        public static void AddCors(this IServiceCollection services, string policyName)
        {
            services.AddCors(o => o.AddPolicy(policyName, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

    }
}
