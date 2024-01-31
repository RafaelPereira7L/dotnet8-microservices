using GeekShopping.ProductAPI.Contexts;
using GeekShopping.ProductAPI.Interfaces;
using GeekShopping.ProductAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Configurations;

public static class DependencyInjection
{
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true); // Make all routes lowercase
            
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention()); // Connect to database
            
            services.AddScoped<IProductRepository, ProductRepository>(); // Register ProductRepository dependency
            
            services.AddAutoMapper(typeof(AutoMapperConfiguration)); // Register AutoMapper dependency
            
            return services;
        }
}