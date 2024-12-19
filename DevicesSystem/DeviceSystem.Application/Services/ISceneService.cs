using DevicesSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevicesSystem.Domain.Models;

namespace DeviceSystem.Application.Services
{
    public interface ISceneService
    {
        void CreateScene(List<Guid> devicesIds);
        void TurnOffSceneDevices(Guid sceneId);
        void TurnOnSceneDevices(Guid sceneId);
        IReadOnlyList<Scene> GetScenes();
    }
}
