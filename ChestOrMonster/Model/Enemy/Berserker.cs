namespace ChestOrMonster.Model.Enemy;

public class Berserker : BaseEntity
{
    private const double MaxHp = 18;

    public override string Name { get; } = "Берсерк";
    public override double Hp { get; protected set; } = MaxHp;
    public override double Atk { get; } = 6;
    public override double Def { get; } = 2;
    public override DamageType AttackType { get; } = DamageType.Usual;
    public override StatusEffect Effect { get; protected set; } = StatusEffect.None;

    public override DamageInfo Attack()
    {
        double rageMultiplier = Hp <= MaxHp / 2 ? 2 : 1;
        return new DamageInfo(Atk * rageMultiplier, AttackType);
    }
}
