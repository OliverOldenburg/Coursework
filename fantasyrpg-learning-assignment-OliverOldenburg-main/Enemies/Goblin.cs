using Enums;
using Enemies;
using BaseClasses;

namespace Enemies
{
    public class Goblin : Enemy
    {
        public Goblin(EnemyRank rank) : base("Goblin", rank)
        {
            Health = 50;
            Mana = 20;
            Strength = 10;
            Agility = 5;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} is scurrying around.");
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} swings its club wildly!");
        }
    }
}