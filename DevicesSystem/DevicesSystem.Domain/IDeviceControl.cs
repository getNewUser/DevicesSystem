namespace DevicesSystem.Domain
{
    public interface IDeviceControl
    {
        Guid Id { get;}
        void TurnOn();
        void TurnOff();
    }
}
