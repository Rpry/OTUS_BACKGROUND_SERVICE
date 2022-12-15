using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExampleService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton((IConfigurationRoot)configuration)
                .ConfigureAutomapper()
                .ConfigureContext(configuration)
                .ConfigureConsumers()
                .ConfigureAllRepositories()
                .ConfigureAllBusinessServices()
                .AddLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddConfiguration(configuration.GetSection("Logging"));
                    builder
                        .AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddConsole();
                })

                .ConfigureContext(configuration);
                
            return services;
        }

        public static IServiceCollection ConfigureConsumers(this IServiceCollection services)
        {
            //Добавить консьюмеры (при необходимости)
            return services;
        }

        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Добавить контекст (при необходимости)
            return services;
        }

        private static IServiceCollection ConfigureAllBusinessServices(this IServiceCollection services)
        {
            //Добавить сервисы БЛ (при необходимости)
            return services;
        }

        private static IServiceCollection ConfigureAllRepositories(this IServiceCollection services)
        {
            //Добавить репозитоии (при необходимости)
            return services; 
        }

        private static IServiceCollection ConfigureAutomapper(this IServiceCollection services) => services
            .AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

        private static MapperConfiguration GetMapperConfiguration()
        {
            //Добавить профайлы мапинга (при необходимости)
            var configuration = new MapperConfiguration(cfg =>
            {
               
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}