using DevicesSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SceneSchedulingController : ControllerBase
    {
        private readonly ISceneScheduler _scheduler;

        public SceneSchedulingController(ISceneScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        [HttpPost]
        [Route("/scheduleSceneCreation")]
        public void ScheduleSceneCreation(List<Guid> devicesIds, DateTime when)
        {
            _scheduler.ScheduleSceneCreation(devicesIds, when);
        }

        [HttpPut]
        [Route("/scheduleSceneTurnOff")]
        public void ScheduleSceneTurnOff(Guid sceneId, DateTime when)
        {
            _scheduler.ScheduleSceneTurnOff(sceneId, when);
        }

        [HttpPut]
        [Route("/scheduleSceneTurnOn")]
        public void ScheduleSceneTurnOn(Guid sceneId, DateTime when)
        {
            _scheduler.ScheduleSceneTurnOn(sceneId, when);
        }
    }
}
