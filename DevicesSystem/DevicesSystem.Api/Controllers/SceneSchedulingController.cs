using DeviceSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SceneSchedulingController(ISceneScheduler scheduler) : ControllerBase
    {
        [HttpPost]
        [Route("/scheduleSceneCreation")]
        public void ScheduleSceneCreation([FromBody] List<Guid> devicesIds, DateTime when)
        {
            scheduler.ScheduleSceneCreation(devicesIds, when);
        }

        [HttpPut]
        [Route("/{sceneId}/scheduleSceneTurnOff")]
        public void ScheduleSceneTurnOff([FromRoute] Guid sceneId, [FromQuery] DateTime when)
        {
            scheduler.ScheduleSceneTurnOff(sceneId, when);
        }

        [HttpPut]
        [Route("/{sceneId}/scheduleSceneTurnOn")]
        public void ScheduleSceneTurnOn([FromRoute] Guid sceneId, [FromQuery] DateTime when)
        {
            scheduler.ScheduleSceneTurnOn(sceneId, when);
        }
    }
}
