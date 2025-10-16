using Enemies;
using BaseClasses;
using Enums;

namespace Factories
{
    public class SlimeFactory : EnemyFactory
    {
        public Enemy CreateEnemy(EnemyRank rank)
        {
            return new Slime(rank);
        }
    }
}
