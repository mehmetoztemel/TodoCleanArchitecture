using Microsoft.Extensions.DependencyInjection;
using TodoCleanArchitecture.Domain.Repositories;
using TodoCleanArchitecture.Infrastructure.Context;
using TodoCleanArchitecture.Infrastructure.Repositories;

namespace TodoCleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // eğer database bağlantısını dışardan okuyorsak bunu kullanmak mantıklı
            //services.AddDbContext<ApplicationDbContext>();
            // Eğer options tanımlaması yapılmayacaksa bunu kullanabiliriz.
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<ITodoRepository, TodoRepository>();
            //services.TryAddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}