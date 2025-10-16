namespace ChestOrMonster.Model.Enemy.Boss;

public class Archmage : Mage
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected override double FrozenRate { get; }
    
    public Archmage()
    {
        Name = "Архимаг";
        Hp = 14;
        Atk = 16;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        FrozenRate = 0.3;
    }
}