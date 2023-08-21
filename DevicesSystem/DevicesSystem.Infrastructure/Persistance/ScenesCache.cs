using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class ScenesCache
    {
        private readonly List<Scene> _scenes = new();

        public void CreateScene(List<ITurnable> devices)
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
