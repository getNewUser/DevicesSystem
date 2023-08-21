using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class DevicesCache
    {
        private readonly List<ITurnable> _devices = new();

        public void AddDevice(ITurnable device)
        {
            _devices.Add(device);
        }

        public ITurnable? GetDevice(Guid id)
        {
            return _devices.SingleOrDefault(x => x.Id == id);
        }

        public List<ITurnable> GetDevices()
        {
            return _devices;
        }

        public List<ITurnable> GetDevices(IReadOnlyList<Guid> ids)
        {
            var idSet = new HashSet<Guid>(ids);
            return _devices.Where(x => idSet.Contains(x.Id)).ToList();
        }

    }
}
