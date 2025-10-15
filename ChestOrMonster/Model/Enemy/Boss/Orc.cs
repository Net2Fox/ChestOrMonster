namespace ChestOrMonster.Model.Enemy.Boss;

public class Orc : Goblin
{
    public override string Name => "Орк";
    public override double Hp => base.Hp * 2;
    public override double Atk => base.Atk * 1.5;
    public override double Def => base.Def * 1.2;
    protected override double CritRate => base.CritRate + 0.1;
}