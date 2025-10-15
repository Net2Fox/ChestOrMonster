using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : BaseEntity
{
    public override string Name { get; protected set; } = "Маг";
    public override double Hp { get; protected set; } = 7;
    public override double Atk => 10;
    public override double Def => 1;
    public override DamageType AttackType => DamageType.Usual;
    public override StatusEffect Effect { get; protected set; } = StatusEffect.None;

    protected virtual double FrozenRate { get; } = 0.2;
    
    public override DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= FrozenRate)
        {
            effect = StatusEffect.Frozen;
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}