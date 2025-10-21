using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Enemy;

public class EnemyDefeatedEvent : IGameEvent
{
    public string EnemyName { get; }

    public EnemyDefeatedEvent(string enemyName)
    {
        EnemyName = enemyName;
    }
}