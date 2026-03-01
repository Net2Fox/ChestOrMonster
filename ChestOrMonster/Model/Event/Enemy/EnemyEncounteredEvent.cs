using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Enemy;

public class EnemyEncounteredEvent : IGameEvent
{
    public List<BaseEntity> Enemies { get; }
    public bool IsBoss { get; }

    public EnemyEncounteredEvent(List<BaseEntity> enemies, bool isBoss = false)
    {
        Enemies = enemies;
        IsBoss = isBoss;
    }
}