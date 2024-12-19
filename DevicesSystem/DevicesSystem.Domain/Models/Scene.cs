namespace DevicesSystem.Domain.Models
{
    public class Scene
    {
        public List<IDeviceControl> Devices { get; }
        public Guid Id { get; }

        public Scene(List<IDeviceControl> devices)
        {
            Id = Guid.NewGuid();
            Devices = devices;
        }

        public void TurnOffDevices()
        {
            foreach (var device in Devices)
            {
                device.TurnOff();
            }
        }

        public void TurnOnDevices()
        {
            foreach (var device in Devices)
            {
                device.TurnOn();
            }
        }
    }
}
