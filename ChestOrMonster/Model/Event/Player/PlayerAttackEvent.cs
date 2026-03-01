using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Player;

public class PlayerAttackEvent : IGameEvent
{
    public BaseEntity Enemy { get; }
    public DamageInfo Damage { get; }
    public double RemainingEnemyHp { get; }
    
    public PlayerAttackEvent(BaseEntity enemy, DamageInfo damage, double remainingEnemyHp)
    {
        Enemy = enemy;
        Damage = damage;
        RemainingEnemyHp = remainingEnemyHp;  
    }
}