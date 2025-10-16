using Enemies;
using BaseClasses;
using Enums;

namespace Factories
{
    public interface EnemyFactory
    {
        Enemy CreateEnemy(EnemyRank rank);
    }
}