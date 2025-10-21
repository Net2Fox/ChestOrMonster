using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Player;

public class PlayerDefeatedEvent : IGameEvent
{
    public string EnemyName { get; }

    public PlayerDefeatedEvent(string enemyName)
    {
        EnemyName = enemyName;
    }
}