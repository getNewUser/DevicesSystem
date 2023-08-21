using DevicesSystem.Infrastructure.Persistance;
using DevicesSystem.Infrastructure.Services;
using DeviceSystem.Application.Services;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Application.Services
{
    internal class SceneScheduler : ISceneScheduler
    {
        private readonly ISceneService _sceneService;
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IActionLogService _actionLogService;

        public SceneScheduler(IBackgroundJobClient backgroundJobs, ISceneService sceneService, IActionLogService actionLogService)
        {
            _backgroundJobs = backgroundJobs;
            _sceneService = sceneService;
            _actionLogService = actionLogService;
        }

        public void ScheduleSceneCreation(List<Guid> devicesIds, DateTime when)
        {
            _backgroundJobs.Schedule(() => _sceneService.CreateScene(devicesIds), when);

            _actionLogService.LogAction($"{nameof(ScheduleSceneCreation)} with devices: {string.Join(Environment.NewLine, devicesIds)}");
        }

        public void ScheduleSceneTurnOff(Guid sceneId, DateTime when)
        {
            _backgroundJobs.Schedule(() => _sceneService.TurnOffSceneDevices(sceneId), when);
            
            _actionLogService.LogAction($"{nameof(ScheduleSceneTurnOff)} for scene: {sceneId}");
        }

        public void ScheduleSceneTurnOn(Guid sceneId, DateTime when)
        {
            _backgroundJobs.Schedule(() => _sceneService.TurnOnSceneDevices(sceneId), when);

            _actionLogService.LogAction($"{nameof(ScheduleSceneTurnOn)} for scene: {sceneId}");
        }
    }
}
