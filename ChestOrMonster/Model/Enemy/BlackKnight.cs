namespace ChestOrMonster.Model.Enemy;

public class BlackKnight : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double ParryChance { get; }

    public BlackKnight()
    {
        Name = "Черный рыцарь";
        Hp = 10;
        Atk = 3;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        ParryChance = 0.5;
    }

    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
    public override DamageInfo Defence()
    {
        double finalDef = Def;
        if (_random.NextDouble() < ParryChance)
        {
            finalDef = 100;
        }
        return new DamageInfo(finalDef);
    }
}