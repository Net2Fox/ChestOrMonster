namespace ChestOrMonster.Model.Enemy.Boss;

public class GiantSkeleton : Skeleton
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    
    public GiantSkeleton()
    {
        Name = "Гигантский скелет";
        Hp = 12;
        Atk = 9;
        Def = 3;
        AttackType = DamageType.Pure;
        Effect = StatusEffect.None;
    }
}