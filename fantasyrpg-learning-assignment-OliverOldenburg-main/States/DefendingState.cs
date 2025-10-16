using System;

namespace States
{
    public class DefendingState : CharacterState
    {
        public void HandleState()
        {
            Console.WriteLine("Character is defending and cannot perform actions.");
        }
    }
}
