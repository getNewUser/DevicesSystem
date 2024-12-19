using DevicesSystem.Domain;

namespace DeviceSystem.Application.Services
{
    public interface IDeviceService
    {
        void AddDevice(IDeviceControl device);
        List<IDeviceControl> GetDevices();
        IDeviceControl? RetrieveDevice(Guid id);
        void UpdateThermostatTemperature(Guid id, double temperature);
        void TurnOnDevice(Guid id);
        void TurnOffDevice(Guid id);
    }
}
