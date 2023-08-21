using DevicesSystem.Domain.Entities;
using DevicesSystem.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DevicesSystem.Api.Serialization
{
    public class TurnableSingleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ITurnable).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            ITurnable device;

            if (jsonObject["Temperature"] != null)
            {
                var temperature = jsonObject["Temperature"].Value<double>();
                device = new Thermostat(temperature);
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

            return device;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonObject = new JObject();

            if (value is Thermostat thermostat)
            {
                jsonObject["Id"] = thermostat.Id.ToString();
                jsonObject["Temperature"] = thermostat.Temperature;
                jsonObject["IsOn"] = thermostat.IsOn;
            }
            else if (value is Lamp lamp)
            {
                jsonObject["Id"] = lamp.Id.ToString();
                jsonObject["IsOn"] = lamp.IsOn;
                jsonObject["Bulb"] = lamp.Bulb.ToString();
            }

            jsonObject.WriteTo(writer);
        }
    }

}
