using DevicesSystem.Application.Services;
using DevicesSystem.Infrastructure.Persistance;
using DeviceSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
