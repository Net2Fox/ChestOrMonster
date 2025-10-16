using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double FrozenRate { get; } = 0.2;
    
    public Mage()
    {
        Name = "Маг";
        Hp = 7;
        Atk = 10;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        FrozenRate = 0.2;
    }
    
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