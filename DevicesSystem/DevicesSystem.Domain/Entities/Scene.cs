using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Domain.Entities
{
    public class Scene
    {
        private readonly Guid _id;
        private readonly List<ITurnable> _devices;

        public List<ITurnable> Devices { get => _devices; }
        public Guid Id { get => _id; }

        public Scene(List<ITurnable> devices)
        {
            _id = Guid.NewGuid();
            _devices = devices;
        }

        public void TurnOffDevices()
        {
            foreach (var device in _devices)
            {
                device.TurnOff();
            }
        }

        public void TurnOnDevices()
        {
            foreach (var device in _devices)
            {
                device.TurnOn();
            }
        }
    }
}
