using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceSystem.Application.Services
{
    public interface IDeviceService
    {
        void AddDevice(ITurnable device);
        List<ITurnable> GetDevices();
        //List<ITurnable> GetDevices(IReadOnlyList<Guid> ids);
        ITurnable? RetrieveDevice(Guid id);
        void UpdateThermostatTemperature(Guid id, double temperature);
        void TurnOnDevice(Guid id);
        void TurnOffDevice(Guid id);
    }
}
