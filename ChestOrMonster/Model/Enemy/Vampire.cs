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

    public Vampire()
    {
        Name = "Вампир";
        Hp = 8;
        Atk = 6;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        LifestealRate = 0.3;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        Hp += finalAtk * LifestealRate;
        return new DamageInfo(finalAtk, AttackType);
    }
}
