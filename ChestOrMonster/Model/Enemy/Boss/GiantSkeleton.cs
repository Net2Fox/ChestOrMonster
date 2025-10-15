namespace ChestOrMonster.Model.Enemy.Boss;

public class GiantSkeleton : Skeleton
{
    public override string Name => "Гигантский скелет";
    public override double Hp => base.Atk * 2.5;
    public override double Atk => base.Atk * 1.3;
    public override double Def => base.Def * 1.4;
}