using DevicesSystem.Api.Serialization;
using DevicesSystem.Domain;
using Newtonsoft.Json;

namespace DevicesSystem.Api.Requests;

public class DeviceCreateRequest
{
    public readonly DeviceType DeviceType;
    [JsonConverter(typeof(DeviceSerializer))]
    public readonly IDeviceControl Device;
    
    public DeviceCreateRequest(DeviceType deviceType, IDeviceControl device)
    {
        DeviceType = deviceType;
        Device = device;
    }
}

public enum DeviceType
{
    Lamp,
    Thermostat
}