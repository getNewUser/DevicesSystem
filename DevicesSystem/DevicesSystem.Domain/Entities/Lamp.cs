using System.Runtime.InteropServices;

namespace DevicesSystem.Domain.Entities
{
    public class Lamp : ITurnable
    {
        private readonly Guid _id = Guid.NewGuid();
        private bool _isOn = false;
        private BulbType _bulb = BulbType.Medium;
        public Guid Id { get => _id; }
        public bool IsOn { get => _isOn; }
        public BulbType Bulb { get => _bulb; }

        public Lamp(BulbType bulb)
        {
            _bulb = bulb;
        }

        public void TurnOn()
        {
            _isOn = true;
        }
        public void TurnOff()
        {
            _isOn = false;
        }
    }
}
