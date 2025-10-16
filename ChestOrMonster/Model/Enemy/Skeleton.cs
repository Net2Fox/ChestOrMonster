using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    
    public Skeleton()
    {
        Name = "Скелет";
        Hp = 5;
        Atk = 7;
        Def = 1;
        AttackType = DamageType.Pure;
        Effect = StatusEffect.None;
    }

    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
}