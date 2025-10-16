using Enums;
using Enemies;
using BaseClasses;

namespace Enemies
{
    public class Dragon : Enemy
    {
        public Dragon(EnemyRank rank) : base("Dragon", rank)
        {
            Health = 200;
            Mana = 100;
            Strength = 50;
            Agility = 20;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} is flying majestically.");
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} breathes a fiery blast!");
        }
    }
}