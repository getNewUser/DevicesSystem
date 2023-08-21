using DevicesSystem.Infrastructure.Models;
using DevicesSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevicesSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        private readonly IActionLogService _actionLogService;

        public LoggingController(IActionLogService actionLogService)
        {
            _actionLogService = actionLogService;
        }

        [HttpGet]
        [Route("/getLogs")]
        public IReadOnlyList<ActionLog> GetLogs()
        {
            return _actionLogService.GetLogs();
        }
    }
}
