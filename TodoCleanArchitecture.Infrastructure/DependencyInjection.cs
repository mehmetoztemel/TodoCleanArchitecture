using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TodoCleanArchitecture.Application.Services;
using TodoCleanArchitecture.Domain.Repositories;
using TodoCleanArchitecture.Infrastructure.Context;
using TodoCleanArchitecture.Infrastructure.Options;
using TodoCleanArchitecture.Infrastructure.Repositories;
using TodoCleanArchitecture.Infrastructure.Services;

namespace TodoCleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IOptionsMonitor<ConnectionStringOptions> connectionOptions)
        {


            // eğer database bağlantısını dışardan okuyorsak bunu kullanmak mantıklı
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionOptions.CurrentValue.SqlServer);
            });
            // Eğer options tanımlaması yapılmayacaksa bunu kullanabiliriz.
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<ITodoRepository, TodoRepository>();
            //services.TryAddScoped<ITodoRepository, TodoRepository>();

            services.AddScoped<ICacheService, MemoryCacheService>();
            //services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }
    }
}