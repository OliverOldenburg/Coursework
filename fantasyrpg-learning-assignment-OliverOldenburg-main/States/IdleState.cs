using System;

namespace States
{
    public class IdleState : CharacterState
    {
        public void HandleState()
        {
            Console.WriteLine("Character is idle.");
        }
    }
}
