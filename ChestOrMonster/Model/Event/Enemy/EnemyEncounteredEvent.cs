using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Enemy;

public class EnemyEncounteredEvent : IGameEvent
{
    public BaseEntity Enemy { get; }
    public bool IsBoss { get; }

    public EnemyEncounteredEvent(BaseEntity enemy, bool isBoss = false)
    {
        Enemy = enemy;
        IsBoss = isBoss;
    }
}