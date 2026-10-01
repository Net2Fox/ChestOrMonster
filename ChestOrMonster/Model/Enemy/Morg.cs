using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Morg : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    public Morg()
    {
        Name = "Морг";
        Hp = 44;
        Atk = 10;
        Def = 5;
        AttackType = DamageType.Pure;
        Effect = StatusEffect.None;
    }
    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
}

