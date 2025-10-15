using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : BaseEntity
{
    public override string Name { get; protected set; } = "Скелет";
    public override double Hp { get; protected set; } = 5;
    public override double Atk => 7;
    public override double Def => 1;
    public override DamageType AttackType => DamageType.Pure;
    public override StatusEffect Effect { get; protected set; } = StatusEffect.None;
    
    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
}