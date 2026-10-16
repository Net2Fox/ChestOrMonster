using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Berserk : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    protected virtual double CritRate { get; }

    public Berserk()
    {
        Name = "Берсерк";
        Hp = 25;
        Atk = 5;
        Def = 0;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        CritRate = 0.2;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        double currentCritRate = CritRate;

        if (Hp < 25 * 0.3)
        {
            currentCritRate *= 2;
        }

        if (_random.NextDouble() < currentCritRate)
        {
            finalAtk *= 1.5;
        }
        return new DamageInfo(finalAtk, AttackType);
    }
}