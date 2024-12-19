using DevicesSystem.Infrastructure.Models;

namespace DevicesSystem.Infrastructure.Services
{
    public interface IActionLogService
    {
        void LogAction(string actionName);
        IReadOnlyList<ActionLog> GetLogs();
    }
}
