namespace DeviceSystem.Application.Services
{
    public interface IDeviceScheduler
    {
        void ScheduleDeviceTurnOn(Guid id, DateTime when);
        void ScheduleDeviceTurnOff(Guid id, DateTime when);
    }
}
