using System;

namespace Strategies
{
    public class HealAction : ActionStrategy
    {
        public void PerformAction()
        {
            Console.WriteLine("Performing a healing action.");
        }
    }
}
