using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Hunter : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double PrecisionBurstChance { get; }

    public Hunter()
    {
        Name = "Охотник";
        Hp = 12;
        Atk = 6;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        PrecisionBurstChance = 0.4;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        if (_random.NextDouble() < PrecisionBurstChance)
        {
            finalAtk *= 1.8;
        }

        return new DamageInfo(finalAtk, AttackType);
    }
}
