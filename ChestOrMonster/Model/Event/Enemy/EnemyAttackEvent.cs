using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Enemy;

public class EnemyAttackEvent : IGameEvent
{
    public BaseEntity Enemy { get; }
    public DamageInfo Damage { get; }
    public double RemainingPlayerHp { get; }
    
    public EnemyAttackEvent(BaseEntity enemy, DamageInfo damage, double remainingPlayerHp)
    {
        Enemy = enemy;
        Damage = damage;
        RemainingPlayerHp = remainingPlayerHp;  
    }
}