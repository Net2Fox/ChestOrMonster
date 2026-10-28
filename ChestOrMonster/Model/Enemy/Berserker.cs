using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

/// <summary>
/// Враг «Берсерк». Уникальная особенность: при здоровье ниже 50%
/// его атака увеличивается на 60%.
/// </summary>
public class Berserker : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    public Berserker()
    {
        Name = "Берсерк";
        Hp = 18;       // больше здоровья, чем у гоблина
        Atk = 4;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
    }

    /// <summary>
    /// Выполняет атаку. Если здоровье ниже половины, сила удара усиливается.
    /// </summary>
    public override DamageInfo Attack()
    {
        double finalAtk = Atk;

        // Уникальная особенность: ярость при низком здоровье
        if (Hp < 9) // меньше половины от 18
        {
            finalAtk *= 1.6; // усиливаем атаку на 60%
        }

        return new DamageInfo(finalAtk, AttackType);
    }
}