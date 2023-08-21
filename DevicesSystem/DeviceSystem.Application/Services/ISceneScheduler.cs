using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Application.Services
{
    public interface ISceneScheduler
    {
        void ScheduleSceneCreation(List<Guid> devicesIds, DateTime when);
        void ScheduleSceneTurnOff(Guid sceneId, DateTime when);
        void ScheduleSceneTurnOn(Guid sceneId, DateTime when);
    }
}
