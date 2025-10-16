using System;

namespace Strategies
{
    public class MeleeAction : ActionStrategy
    {
        public void PerformAction()
        {
            Console.WriteLine("Performing a melee attack.");
        }
    }
}
