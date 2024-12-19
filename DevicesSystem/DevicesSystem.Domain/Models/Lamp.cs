namespace DevicesSystem.Domain.Models
{
    public class Lamp : IDeviceControl
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsOn { get; private set; }
        public BulbType Bulb { get; private set; }

        public Lamp(BulbType bulb)
        {
            Bulb = bulb;
        }

        public void TurnOn()
        {
            IsOn = true;
        }
        public void TurnOff()
        {
            IsOn = false;
        }
    }
}
