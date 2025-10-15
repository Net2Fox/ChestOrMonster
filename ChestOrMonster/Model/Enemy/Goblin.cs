using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Goblin : BaseEntity
{
    public override string Name { get; protected set; } = "Гоблин";
    public override double Hp { get; protected set; } = 10;
    public override double Atk => 3;
    public override double Def => 1;
    public override DamageType AttackType => DamageType.Usual;
    public override StatusEffect Effect { get; protected set; } = StatusEffect.None;
    protected virtual double CritRate { get; } = 0.3;

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