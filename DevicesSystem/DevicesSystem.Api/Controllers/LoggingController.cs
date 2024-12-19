using DevicesSystem.Infrastructure.Models;
using DevicesSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController(IActionLogService actionLogService) : ControllerBase
    {
        [HttpGet]
        [Route("/getLogs")]
        public IReadOnlyList<ActionLog> GetLogs()
        {
            return actionLogService.GetLogs();
        }
    }
}
