using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Beatles : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double CritRate { get; }

    public Beatles()
    {
        Name = "Гоблин";
        Hp = 20;
        Atk = 6;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        CritRate = 0.3;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        if (_random.NextDouble() < CritRate)
        {
            finalAtk *= 1.5;
        }
        return new DamageInfo(finalAtk, AttackType);
    }
}
