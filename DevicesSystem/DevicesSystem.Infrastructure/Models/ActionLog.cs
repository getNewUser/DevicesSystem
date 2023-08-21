using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Models
{
    public record ActionLog(string actionName, DateTime actionTime);
}
