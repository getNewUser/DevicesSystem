using DevicesSystem.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using DeviceSystem.Application.Services;
using DevicesSystem.Domain;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController(IDeviceService service) : ControllerBase
    {
        [HttpPost]
        [Route("/addDevice")]
        public void AddDevice([FromBody]DeviceCreateRequest device)
        {
            service.AddDevice(device.Device);
        }

        [HttpGet]
        [Route("/{id}/retrieveDevice")]
        public IDeviceControl? RetrieveDevice([FromRoute] Guid id)
        {
            return service.RetrieveDevice(id);
        }

        [HttpPut]
        [Route("/{id}/updateThermostatTemperature")]
        public void UpdateThermostatTemperature([FromRoute] Guid id, [FromQuery] double temperature)
        {
            service.UpdateThermostatTemperature(id, temperature);
        }

        [HttpPut]
        [Route("/{id}/turnOnDevice")]
        public void TurnOnDevice([FromRoute] Guid id)
        {
            service.TurnOnDevice(id);
        }

        [HttpPut]
        [Route("/{id}/turnOffDevice")]
        public void TurnOffDevice([FromRoute] Guid id)
        {
            service.TurnOffDevice(id);
        }

        [HttpGet]
        [Route("/getDevices")]
        public IReadOnlyList<IDeviceControl> GetDevices()
        {
            return service.GetDevices();
        }
    }
}
