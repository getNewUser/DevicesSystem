namespace DeviceSystem.Application.Services
{
    public interface ISceneScheduler
    {
        void ScheduleSceneCreation(List<Guid> devicesIds, DateTime when);
        void ScheduleSceneTurnOff(Guid sceneId, DateTime when);
        void ScheduleSceneTurnOn(Guid sceneId, DateTime when);
    }
}
