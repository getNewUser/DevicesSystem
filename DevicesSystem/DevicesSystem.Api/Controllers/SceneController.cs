using DevicesSystem.Domain.Models;
using DeviceSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SceneController(ISceneService service) : ControllerBase
    {
        [HttpPost]
        [Route("/createScene")]
        public void CreateScene([FromBody] List<Guid> devices)
        {
            service.CreateScene(devices);
        }
        
        [HttpPut]
        [Route("/{sceneId}/turnOnDevices")]
        public void TurnOnSceneDevices([FromRoute] Guid sceneId)
        {
            service.TurnOnSceneDevices(sceneId);
        }

        [HttpPut]
        [Route("/{sceneId}/turnOffDevices")]
        public void TurnOffSceneDevices([FromRoute] Guid sceneId)
        {
            service.TurnOffSceneDevices(sceneId);
        }

        [HttpGet]
        [Route("/getScenes")]
        public IReadOnlyList<Scene> GetScenes()
        {
            return service.GetScenes();
        }
    }
}
