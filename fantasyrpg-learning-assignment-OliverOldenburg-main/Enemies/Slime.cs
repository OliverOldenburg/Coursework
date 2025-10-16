using Enums;
using Enemies;
using BaseClasses;

namespace Enemies
{
    public class Slime : Enemy
    {
        public Slime(EnemyRank rank) : base("Slime", rank)
        {
            Health = 30;
            Mana = 10;
            Strength = 5;
            Agility = 2;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} is oozing forward slowly.");
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a sticky slap!");
        }
    }
}