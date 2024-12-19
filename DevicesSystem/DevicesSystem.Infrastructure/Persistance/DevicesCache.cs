using DevicesSystem.Domain;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class DevicesCache
    {
        private readonly List<IDeviceControl> _devices = new();

        public void AddDevice(IDeviceControl device)
        {
            _devices.Add(device);
        }

        public IDeviceControl? GetDevice(Guid id)
        {
            return _devices.SingleOrDefault(x => x.Id == id);
        }

        public List<IDeviceControl> GetDevices()
        {
            return _devices;
        }

        public List<IDeviceControl> GetDevices(IReadOnlyList<Guid> ids)
        {
            var idSet = new HashSet<Guid>(ids);
            return _devices.Where(x => idSet.Contains(x.Id)).ToList();
        }
    }
}
