
namespace ChestOrMonster.Model.Enemy;

public class Tank : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double BloodRate { get; }

    public Tank()
    {
        Name = "Танк Panzer IV";
        Hp = 300;
        Atk = 19;
        Def = 15;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        BloodRate = 0.2;
    }

    public override DamageInfo Attack()
    {
        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= BloodRate)
        {
            Console.WriteLine("UJQLF");
            effect = StatusEffect.BloodLose;
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}