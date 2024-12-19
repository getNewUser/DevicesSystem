using DevicesSystem.Infrastructure.Services;
using Hangfire;

namespace DeviceSystem.Application.Services
{
    public class DeviceScheduler : IDeviceScheduler
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private readonly IDeviceService _service;
        private readonly IActionLogService _actionLogService;


        public DeviceScheduler(IBackgroundJobClient backgroundJobs, IDeviceService service, IActionLogService actionLogService)
        {
            _backgroundJobs = backgroundJobs;
            _service = service;
            _actionLogService = actionLogService;
        }

        public void ScheduleDeviceTurnOn(Guid id, DateTime when)
        {
            _backgroundJobs.Schedule(() => _service.TurnOnDevice(id), when);

            _actionLogService.LogAction($"{nameof(ScheduleDeviceTurnOn)} on device: {id}");
        }

        public void ScheduleDeviceTurnOff(Guid id, DateTime when)
        {
            _backgroundJobs.Schedule(() => _service.TurnOffDevice(id), when);

            _actionLogService.LogAction($"{nameof(ScheduleDeviceTurnOff)} on device: {id}");
        }
    }
}
