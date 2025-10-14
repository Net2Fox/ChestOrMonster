using ChestOrMonster.Interface;
using ChestOrMonster.Model.Enemy;

namespace ChestOrMonster.Factory;

public static class EnemyFactory
{
    private static Random _random = Random.Shared;

    public static IBaseEnemy CreateRandomEnemy()
    {
        int roll = _random.Next(0, 3);
        return roll switch
        {
            0 => new Goblin(),
            1 => new Skeleton(),
            2 => new Mage()
        };
    }
}