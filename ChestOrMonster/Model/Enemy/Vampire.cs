using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Vampire : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double LifestealRate { get; }

    private readonly double _maxHp;

    public Vampire()
    {
        Name = "Вампир";
        Hp = 10;
        Atk = 4;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        LifestealRate = 0.1;
        _maxHp = Hp;
    }

    public override DamageInfo Attack()
    {
        Hp = Math.Min(_maxHp, Hp + Atk * LifestealRate);
        return new DamageInfo(Atk, AttackType);
    }
}
