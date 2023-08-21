namespace DevicesSystem.Domain.Entities
{
    public class Thermostat : ITurnable
    {
        private readonly Guid _id;
        private double _temperature;
        private bool _isOn;

        public Guid Id { get => _id; }
        public double Temperature { get => _temperature; set => _temperature = value; }
        public bool IsOn { get => _isOn; }

        public Thermostat(double temperature)
        {
            _id = Guid.NewGuid();
            _temperature = temperature;
            _isOn = false;
        }

        public void TurnOn()
        {
            _isOn = true;
        }
        public void TurnOff()
        {
            _isOn = false;
        }

        public void ChangeTemperature(double newTemperature)
        {
            _temperature = newTemperature;
        }

    }
}
