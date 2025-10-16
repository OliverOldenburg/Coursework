using System;

namespace Strategies
{
    public class MagicAction : ActionStrategy
    {
        public void PerformAction()
        {
            Console.WriteLine("Casting a magic spell.");
        }
    }
}
