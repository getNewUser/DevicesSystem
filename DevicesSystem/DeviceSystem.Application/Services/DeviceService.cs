using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using DevicesSystem.Infrastructure.Persistance;
using DevicesSystem.Infrastructure.Services;

namespace DeviceSystem.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DevicesCache _cache;
        private readonly IActionLogService _actionLogService;

        public DeviceService(DevicesCache cache, IActionLogService actionLogService)
        {
            _cache = cache;
            _actionLogService = actionLogService;
        }

        public void AddDevice(ITurnable device) => _cache.AddDevice(device);

        public List<ITurnable> GetDevices() => _cache.GetDevices();

        public ITurnable? RetrieveDevice(Guid id) => _cache.GetDevice(id);

        public void UpdateThermostatTemperature(Guid id, double temperature)
        {
            var device = _cache.GetDevice(id);
            if (device is not null and Thermostat)
            {
                var thermostat = (Thermostat)device;
                thermostat.ChangeTemperature(temperature);
            }

            _actionLogService.LogAction($"{nameof(UpdateThermostatTemperature)} on device: {id}");
        }

        public void TurnOnDevice(Guid id)
        {
            var device = _cache.GetDevice(id);
            device?.TurnOn();

            _actionLogService.LogAction($"{nameof(TurnOnDevice)} on device: {id}");
        }
        public void TurnOffDevice(Guid id)
        {
            var device = _cache.GetDevice(id);
            device?.TurnOff();

            _actionLogService.LogAction($"{nameof(TurnOffDevice)} on device: {id}");
        }
    }
}
