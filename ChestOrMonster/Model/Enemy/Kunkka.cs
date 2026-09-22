using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Kunkka : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get;  }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double DoubleDamage { get; }

    public Kunkka()
    {
        Name = "Кунка";
        Hp = 8;
        Atk = 5;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        DoubleDamage = 0.5;
    }
    
    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        if (_random.NextDouble() < DoubleDamage)
        {
            finalAtk *= 2;
        }
        return new DamageInfo(finalAtk, AttackType);
    }
}