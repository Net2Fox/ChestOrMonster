using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Player;

public class PlayerAttackEvent : IGameEvent
{
    public DamageInfo Damage { get; }
    public double RemainingEnemyHp { get; }
    
    public PlayerAttackEvent(DamageInfo damage, double remainingEnemyHp)
    {
        Damage = damage;
        RemainingEnemyHp = remainingEnemyHp;  
    }
}