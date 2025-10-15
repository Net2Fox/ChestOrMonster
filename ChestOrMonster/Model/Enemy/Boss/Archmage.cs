namespace ChestOrMonster.Model.Enemy.Boss;

public class Archmage : Mage
{
    public override string Name => "Маг";
    public override double Hp => base.Atk * 1.8;
    public override double Atk => base.Atk * 1.6;
    public override double Def => base.Def * 1.1;
    protected override double FrozenRate => base.FrozenRate + 0.1;
}