using LibraryManagement.Application.Abstractions;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Infrastructure.BaseRepositories;
using LibraryManagement.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagement.Infrastructure
{
    public static class ProductComparisionDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductComparisionDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"));
                //options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("ProductComparision.Infrastructure"));


            });

            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }

    }
}
