using DevicesSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Application.Services
{
    public interface IDeviceScheduler
    {
        void ScheduleDeviceTurnOn(Guid id, DateTime when);
        void ScheduleDeviceTurnOff(Guid id, DateTime when);
    }
}
