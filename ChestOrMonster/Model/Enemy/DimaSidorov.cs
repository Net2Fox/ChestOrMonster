using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class DimaSidorov : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    public DimaSidorov()
    {
        Name = "Дима Сидоров";
        Hp = 1;
        Atk = 10;
        Def = 2;
        AttackType = DamageType.Pure;
        Effect = StatusEffect.None;
    }

    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
}