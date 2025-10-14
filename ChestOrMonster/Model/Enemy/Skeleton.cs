using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : IBaseEnemy
{
    private static Random _random = Random.Shared;

    
    public string Name { get; private set; } = "Скелет";
    public double Hp { get; private set; } = 5;
    public double Atk { get; private set; } = 7;
    public double Def { get; private set; } = 1;
    public DamageType AttackType { get; private set; } = DamageType.Pure;
    public StatusEffect Effect { get; private set; } = StatusEffect.None;
    
    public DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }

    public double Defend()
    {
        return Def;
    }

    public DamageInfo TakeDamage(DamageInfo damage)
    {
        switch (damage.Type)
        {
            case DamageType.Physical:
                double def = Def * (_random.Next(70, 101) / 100d);
                damage.ChangeDamageAmount(damage.Amount - def);
                break;
        }
        
        Effect = damage.Effect;
        Hp -= damage.Amount;
        return damage;
    }
}