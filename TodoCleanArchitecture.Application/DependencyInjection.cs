using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoCleanArchitecture.Application.Behaviors;

namespace TodoCleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                // bütün yapıda kullanacaksak bunu ekliyoruz.
                //configuration.AddOpenBehavior(typeof(ExampleBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
