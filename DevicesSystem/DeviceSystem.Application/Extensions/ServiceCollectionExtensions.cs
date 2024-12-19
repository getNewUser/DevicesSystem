using DeviceSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceSystem.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<ISceneService, SceneService>();
            services.AddTransient<IDeviceScheduler, DeviceScheduler>();
            services.AddTransient<ISceneScheduler, SceneScheduler>();
            return services;
        }
    }
}
