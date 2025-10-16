using System;
using Strategies;

namespace States
{
    public class ActionState : CharacterState
    {
        private ActionStrategy _actionStrategy;

        public ActionState(ActionStrategy actionStrategy)
        {
            _actionStrategy = actionStrategy;
        }

        public void HandleState()
        {
            Console.WriteLine("Character is performing an action.");
            _actionStrategy.PerformAction();
        }

        public void SetActionStrategy(ActionStrategy actionStrategy)
        {
            _actionStrategy = actionStrategy;
        }
    }
}
