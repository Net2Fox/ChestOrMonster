namespace ChestOrMonster.Model.Enemy;

public class Ghost : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double PhaseChance { get; }

    public Ghost()
    {
        Name = "Призрак";
        Hp = 8;
        Atk = 5;
        Def = 0;
        AttackType = DamageType.Pure;
        Effect = StatusEffect.None;
        PhaseChance = 0.3;
    }

    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }

    public override DamageInfo TakeDamage(DamageInfo damage)
    {
        if (_random.NextDouble() < PhaseChance)
        {
            damage = new DamageInfo(0, damage.Type, damage.Effect);
        }
        return base.TakeDamage(damage);
    }
}