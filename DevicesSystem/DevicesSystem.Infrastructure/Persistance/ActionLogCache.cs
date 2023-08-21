using DevicesSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class ActionLogCache
    {
        private readonly List<ActionLog> _actions = new();
        public IReadOnlyList<ActionLog> Actions => _actions;

        public void AddAction(ActionLog action)
        {
            _actions.Add(action);
        }
    }
}
