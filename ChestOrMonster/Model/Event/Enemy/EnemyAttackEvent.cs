using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Event.Enemy;

public class EnemyAttackEvent : IGameEvent
{
    public DamageInfo Damage { get; }
    public double RemainingPlayerHp { get; }
    
    public EnemyAttackEvent(DamageInfo damage, double remainingPlayerHp)
    {
        Damage = damage;
        RemainingPlayerHp = remainingPlayerHp;  
    }
}