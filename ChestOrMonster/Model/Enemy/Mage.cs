using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : IBaseEnemy
{
    private static Random _random = new(DateTime.Now.Millisecond);

    public string Name { get; private set; } = "Маг";
    public double Hp { get; private set; } = 7;
    public double Atk { get; private set; } = 10;
    public double Def { get; private set; } = 1;
    public DamageType AttackType { get; private set; } = DamageType.Physical;
    public StatusEffect Effect { get; private set; } = StatusEffect.None;

    private double FrozenRate { get; set; } = 0.2;
    
    public DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= FrozenRate)
        {
            effect = StatusEffect.Frozen;
        }
        return new DamageInfo(Atk, AttackType, effect);
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