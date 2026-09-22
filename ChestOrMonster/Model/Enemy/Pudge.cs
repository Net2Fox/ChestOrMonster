using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Pudge : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get;  }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double RotRate { get; }

    public Pudge()
    {
        Name = "Пуджик";
        Hp = 50;
        Atk = 1;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        RotRate = 0.4;
    }
    
    public override DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= RotRate)
        {
            effect = StatusEffect.Rot;
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}