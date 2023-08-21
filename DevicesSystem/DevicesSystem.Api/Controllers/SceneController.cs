using DevicesSystem.Api.Serialization;
using DevicesSystem.Domain;
using DevicesSystem.Domain.Entities;
using DeviceSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly ISceneService _service;

        public SceneController(ISceneService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/createScene")]
        public void CreateScene([FromBody] List<Guid> devices)
        {
            _service.CreateScene(devices);
        }
        
        [HttpPut]
        [Route("/turnOnDevices")]
        public void TurnOnSceneDevices([FromQuery] Guid sceneId)
        {
            _service.TurnOnSceneDevices(sceneId);
        }

        [HttpPut]
        [Route("/turnOffDevices")]
        public void TurnOffSceneDevices([FromQuery] Guid sceneId)
        {
            _service.TurnOffSceneDevices(sceneId);
        }

        [HttpGet]
        [Route("/getScenes")]
        public IReadOnlyList<Scene> GetScenes()
        {
            return _service.GetScenes();
        }
    }
}
