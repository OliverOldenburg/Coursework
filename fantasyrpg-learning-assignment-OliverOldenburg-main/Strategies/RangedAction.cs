using System;

namespace Strategies
{
    public class RangedAction : ActionStrategy
    {
        public void PerformAction()
        {
            Console.WriteLine("Performing a ranged attack.");
        }
    }
}
