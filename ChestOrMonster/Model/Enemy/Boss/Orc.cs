namespace ChestOrMonster.Model.Enemy.Boss;

public class Orc : Goblin
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get;  }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected override double CritRate { get; }
    
    public Orc()
    {
        Name = "Орк";
        Hp = 80;
        Atk = 7;
        Def = 2;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        CritRate = 0.4;
    }
   
}