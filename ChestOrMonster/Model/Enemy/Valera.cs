using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Valera : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double SuddenCriticalBloodPressureIncreaseChance { get; } = 0.1;

    public Valera()
    {
        Name = "Данилов Валера";
        Hp = 5;
        Atk = 1;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        SuddenCriticalBloodPressureIncreaseChance = 0.1;
    }

    public override DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= SuddenCriticalBloodPressureIncreaseChance)
        {
            Hp = 1;
            return new DamageInfo(0, AttackType, effect);
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}