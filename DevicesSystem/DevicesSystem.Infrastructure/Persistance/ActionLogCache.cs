using DevicesSystem.Infrastructure.Models;

namespace DevicesSystem.Infrastructure.Persistance
{
    public class ActionLogCache
    {
        private readonly List<ActionLog> _actions = [];
        public IReadOnlyList<ActionLog> Actions => _actions;

        public void AddAction(ActionLog action)
        {
            _actions.Add(action);
        }
    }
}
