using DeviceSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceSchedulingController(IDeviceScheduler scheduler) : ControllerBase
    {
        [HttpPost]
        [Route("/{id}/turnOnDevice")]
        public void ScheduleDeviceTurnOn([FromRoute] Guid id, [FromQuery] DateTime when)
        {
            scheduler.ScheduleDeviceTurnOn(id, when);
        }

        [HttpPost]
        [Route("/{id}/turnOffDevice")]
        public void ScheduleDeviceTurnOff([FromRoute] Guid id, [FromQuery] DateTime when)
        {
            scheduler.ScheduleDeviceTurnOff(id, when);
        }
    }
}
