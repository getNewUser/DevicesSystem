using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using DevicesSystem.Infrastructure.Persistance;
using DevicesSystem.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSystem.Application.Services
{
    public class SceneService : ISceneService
    {
        private readonly ScenesCache _cache;
        private readonly DevicesCache _devicesCache;
        private readonly IActionLogService _actionLogService;

        public SceneService(ScenesCache cache, DevicesCache devicesCache, IActionLogService actionLogService)
        {
            _cache = cache;
            _devicesCache = devicesCache;
            _actionLogService = actionLogService;
        }

        public void CreateScene(List<Guid> devicesIds)
        {
            var devices = _devicesCache.GetDevices(devicesIds);
            _cache.CreateScene(devices);


            _actionLogService.LogAction($"{nameof(CreateScene)} with devices: {string.Join(Environment.NewLine, devicesIds)}");
        }

        public void TurnOffSceneDevices(Guid sceneId)
        {
            var scene = _cache.GetScene(sceneId);
            foreach (var device in scene.Devices)
            {
                device.TurnOff();
            }

            _actionLogService.LogAction($"{nameof(TurnOffSceneDevices)} for scene: {sceneId}");
        }

        public void TurnOnSceneDevices(Guid sceneId)
        {
            var scene = _cache.GetScene(sceneId);
            foreach (var device in scene.Devices)
            {
                device.TurnOn();
            }


            _actionLogService.LogAction($"{nameof(TurnOnSceneDevices)} for scene: {sceneId}");
        }

        public IReadOnlyList<Scene> GetScenes()
        {
            return _cache.GetScenes();
        }
    }
}
