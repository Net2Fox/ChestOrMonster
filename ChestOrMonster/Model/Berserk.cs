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

    protected double RageMultiplier { get; }

    public Berserk()
    {
        Name = "Берсерк";
        Hp = 15;
        Atk = 4;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;

        RageMultiplier = 1.5;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;

        // Ярость при HP <= 50%
        if (Hp <= 7.5)
        {
            finalAtk *= RageMultiplier;
        }

        return new DamageInfo(finalAtk, AttackType);
    }
}