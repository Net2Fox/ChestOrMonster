namespace ChestOrMonster.Model.Enemy;

public class You : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    public You(Player player)
    {
        Name = "Ты";

        Hp = player.Hp;
        Atk = player.Weapon.Damage ;
        Def = player.Armor.Def ;

        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
    }

    public override DamageInfo Attack()
    {
        return new DamageInfo(Atk, AttackType);
    }
}