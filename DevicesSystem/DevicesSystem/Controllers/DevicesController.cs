using DevicesSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DeviceSystem.Application.Services;
using DevicesSystem.Domain;
using DevicesSystem.Api.Serialization;
using Newtonsoft.Json;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _service;

        public DevicesController(IDeviceService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/addDevice")]
        public void AddDevice([FromBody][JsonConverter(typeof(TurnableSingleConverter))] ITurnable device)
        {
            _service.AddDevice(device);
        }

        [HttpGet]
        [Route("/retrieveDevice")]
        public ITurnable? RetrieveDevice([FromQuery] Guid id)
        {
            return _service.RetrieveDevice(id);
        }

        [HttpPut]
        [Route("/updateThermostatTemperature")]
        public void UpdateThermostatTemperature([FromQuery] Guid id, [FromQuery] double temperature)
        {
            _service.UpdateThermostatTemperature(id, temperature);
        }

        [HttpPut]
        [Route("/turnOnDevice")]
        public void TurnOnDevice([FromQuery] Guid id)
        {
            _service.TurnOnDevice(id);
        }

        [HttpPut]
        [Route("/turnOffDevice")]
        public void TurnOffDevice([FromQuery] Guid id)
        {
            _service.TurnOffDevice(id);
        }

        [HttpGet]
        [Route("/getDevices")]
        public IReadOnlyList<ITurnable> GetDevices()
        {
            return _service.GetDevices();
        }
    }
}
