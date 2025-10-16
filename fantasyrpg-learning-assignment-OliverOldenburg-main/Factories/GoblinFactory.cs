using Enemies;
using BaseClasses;
using Enums;

namespace Factories
{
    public class GoblinFactory : EnemyFactory
    {
        public Enemy CreateEnemy(EnemyRank rank)
        {
            return new Goblin(rank);
        }
    }
}
