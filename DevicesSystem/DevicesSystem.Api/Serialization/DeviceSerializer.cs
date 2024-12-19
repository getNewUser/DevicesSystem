using DevicesSystem.Api.Requests;
using DevicesSystem.Domain;
using DevicesSystem.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevicesSystem.Api.Serialization
{
    public class DeviceSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(DeviceCreateRequest).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (jsonObject["deviceType"] == null)
            {
                throw new JsonSerializationException("DeviceType field is missing.");
            }

            if (!Enum.TryParse(jsonObject["deviceType"]?.ToString(), out DeviceType deviceType))
            {
                throw new JsonSerializationException("Invalid DeviceType value.");
            }

            var deviceObject = jsonObject["device"];
            if (deviceObject == null)
            {
                throw new JsonSerializationException("Device field is missing.");
            }

            IDeviceControl device;
            switch (deviceType)
            {
                case DeviceType.Thermostat:
                    if (deviceObject["temperature"] == null)
                    {
                        throw new JsonSerializationException("Temperature field is missing.");
                    }
                    var temperature = (deviceObject["temperature"] ?? throw new InvalidOperationException()).Value<double>();
                    device = new Thermostat(temperature);
                    break;
                case DeviceType.Lamp:
                    if (deviceObject["bulb"] == null)
                    {
                        throw new JsonSerializationException("Bulb field is missing.");
                    }
                    if (Enum.TryParse(deviceObject["bulb"]?.ToString(), out BulbType bulb))
                    {
                        device = new Lamp(bulb);
                    }
                    else
                    {
                        throw new JsonSerializationException("Invalid BulbType value.");
                    }
                    break;
                default:
                    throw new JsonSerializationException("Unsupported DeviceType.");
            }

            return new DeviceCreateRequest(deviceType, device);
        }
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var jsonObject = new JObject();

            switch (value)
            {
                case Thermostat thermostat:
                    jsonObject["deviceType"] = DeviceType.Thermostat.ToString();
                    jsonObject["id"] = thermostat.Id.ToString();
                    jsonObject["temperature"] = thermostat.Temperature;
                    jsonObject["isOn"] = thermostat.IsOn;
                    break;
                case Lamp lamp:
                    jsonObject["deviceType"] = DeviceType.Lamp.ToString();
                    jsonObject["id"] = lamp.Id.ToString();
                    jsonObject["isOn"] = lamp.IsOn;
                    jsonObject["bulb"] = lamp.Bulb.ToString();
                    break;
            }

            jsonObject.WriteTo(writer);
        }
    }
}