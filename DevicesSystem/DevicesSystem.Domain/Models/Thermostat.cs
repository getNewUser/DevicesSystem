namespace DevicesSystem.Domain.Models
{
    public class Thermostat : IDeviceControl
    {
        public Guid Id { get; }
        public double Temperature { get; private set; }

        public bool IsOn { get; private set; }

        public Thermostat(double temperature)
        {
            Id = Guid.NewGuid();
            Temperature = temperature;
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
        }
        public void TurnOff()
        {
            IsOn = false;
        }

        public void ChangeTemperature(double newTemperature)
        {
            Temperature = newTemperature;
        }

    }
}
