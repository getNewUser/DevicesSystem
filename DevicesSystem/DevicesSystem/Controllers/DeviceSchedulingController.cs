using DevicesSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceSchedulingController : ControllerBase
    {
        private readonly IDeviceScheduler _scheduler;

        public DeviceSchedulingController(IDeviceScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        [HttpPost]
        [Route("/turnOnDevice")]
        public void ScheduleDeviceTurnOn([FromQuery] Guid id, [FromQuery] DateTime when)
        {
            _scheduler.ScheduleDeviceTurnOn(id, when);
        }

        [HttpPost]
        [Route("/turnOffDevice")]
        public void ScheduleDeviceTurnOff([FromQuery] Guid id, [FromQuery] DateTime when)
        {
            _scheduler.ScheduleDeviceTurnOff(id, when);
        }
    }
}
