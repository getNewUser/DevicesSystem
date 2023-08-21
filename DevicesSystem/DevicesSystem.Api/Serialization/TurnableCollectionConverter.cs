using DevicesSystem.Domain.Entities;
using DevicesSystem.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DevicesSystem.Api.Serialization
{
    public class TurnableCollectionConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var devices = new List<ITurnable>();
            var jsonArray = JArray.Load(reader);

            foreach (var jsonObject in jsonArray.Children<JObject>())
            {
                ITurnable device;
                if (jsonObject["Temperature"] != null)
                {
                    device = new Thermostat(jsonObject["Temperature"].Value<double>());
                }
                else if (jsonObject["Bulb"] != null)
                {
                    if (Enum.TryParse(jsonObject["Bulb"].ToString(), out BulbType bulb))
                    {
                        device = new Lamp(bulb);
                    }
                    else
                    {
                        throw new JsonSerializationException("Invalid BulbType value.");
                    }
                }
                else
                {
                    throw new ArgumentException("Wrong type of device provided");
                }

                device.TurnOn();
                devices.Add(device);
            }

            return devices;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonArray = new JArray();
            var devices = value as List<ITurnable>;

            foreach (var device in devices)
            {
                var jsonObject = new JObject();
                jsonObject.Add("Id", device.Id);

                if (device is Thermostat thermostat)
                {
                    jsonObject["Temperature"] = thermostat.Temperature;
                    jsonObject["IsOn"] = thermostat.IsOn;
                }
                else if (device is Lamp lamp)
                {
                    jsonObject["IsOn"] = lamp.IsOn;
                    jsonObject["Bulb"] = lamp.Bulb.ToString();
                }

                jsonArray.Add(jsonObject);
            }

            jsonArray.WriteTo(writer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<ITurnable>) || objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>) && objectType.GenericTypeArguments[0] == typeof(ITurnable);
        }
    }
}
