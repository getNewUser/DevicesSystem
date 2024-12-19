using DevicesSystem.Domain;
using DevicesSystem.Domain.Models;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class ScenesCache
    {
        private readonly List<Scene> _scenes = new();

        public void CreateScene(List<IDeviceControl> devices)
        {
            var scene = new Scene(devices);
            _scenes.Add(scene);
        }

        public Scene? GetScene(Guid id)
        {
            return _scenes.SingleOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<Scene> GetScenes()
        {
            return _scenes;
        }
    }
}
