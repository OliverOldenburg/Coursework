using Enemies;
using BaseClasses;
using Enums;

namespace Factories
{
    public class DragonFactory : EnemyFactory
    {
        public Enemy CreateEnemy(EnemyRank rank)
        {
            return new Dragon(rank);
        }
    }
}