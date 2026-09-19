using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;
public class SashaAntonov : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    private bool _powerAttack;

    public SashaAntonov()
    {
        Name = "Сашка Антонов";
        Hp = 20;
        Atk = 5;
        Def = 3;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;

        _powerAttack = false;
    }

    public override DamageInfo Attack()
    {
        double finalAttack = Atk;

        if (_powerAttack)
        {
            finalAttack *= 2;
        }

        _powerAttack = !_powerAttack;

        return new DamageInfo(finalAttack, AttackType);
    }
}
