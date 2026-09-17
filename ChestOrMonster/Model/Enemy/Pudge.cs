namespace ChestOrMonster.Model.Enemy;

public class Pudge : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get;  }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double CritRate { get; }

    public Pudge()
    {
        Name = "Пудж";
        Hp = 100;
        Atk = 3;
        Def = 5;
        AttackType = DamageType.Magic;
        Effect = StatusEffect.Burning;
        CritRate = 0.5;
    }
    
    public override DamageInfo Attack()
    {
        double finalAtk = Atk * CritRate;
        if (_random.NextDouble() > CritRate)
        {
            finalAtk *= 2.0;
        }
        return new DamageInfo(finalAtk, AttackType, StatusEffect.Burning);
    }
}