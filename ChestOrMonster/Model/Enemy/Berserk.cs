using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Berserk : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get;  }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double HealRate { get; }

    public Berserk()
    {
        Name = "Берсерк";
        Hp = 16;
        Atk = 7;
        Def = 4;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        HealRate = 0.2;
    }
    
    public override DamageInfo Attack()
    {
        if (_random.NextDouble() < HealRate)
        {
            Hp += 5;
        }
        return new DamageInfo(Atk, AttackType);
    }
}