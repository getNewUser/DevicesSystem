using DevicesSystem.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.MemoryStorage;
using DevicesSystem.Infrastructure.Services;

namespace DevicesSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<DevicesCache>();
            services.AddSingleton<ScenesCache>();
            services.AddSingleton<ActionLogCache>();

            services.AddTransient<IActionLogService, ActionLogService>();

            services.AddHangfire(config => config
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage()); // Using in-memory storage

            services.AddHangfireServer();

            return services;
        }
    }
}
