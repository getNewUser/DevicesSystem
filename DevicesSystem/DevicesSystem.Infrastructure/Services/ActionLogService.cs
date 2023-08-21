using DevicesSystem.Infrastructure.Models;
using DevicesSystem.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Services
{
    public class ActionLogService : IActionLogService
    {
        private readonly ActionLogCache _cache;

        public ActionLogService(ActionLogCache cache)
        {
            _cache = cache;
        }

        public void LogAction(string actionName) => _cache.AddAction(new ActionLog(actionName, DateTime.UtcNow));

        public IReadOnlyList<ActionLog> GetLogs()
        {
            return _cache.Actions;
        }
    }
}
