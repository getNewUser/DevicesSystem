using DevicesSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Services
{
    public interface IActionLogService
    {
        void LogAction(string actionName);
        IReadOnlyList<ActionLog> GetLogs();
    }
}
