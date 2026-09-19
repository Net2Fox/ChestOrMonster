using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Cat : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double BleedingRate { get; } = 0.7;

    public Cat()
    {
        Name = "Кот";
        Hp = 10000;
        Atk = 100;
        Def = 5;
        AttackType = DamageType.AttackOfCat;
        Effect = StatusEffect.None;
        BleedingRate = 0.7;
    }

    public override DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() < BleedingRate)
        {
            effect = StatusEffect.Bleeding;
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}