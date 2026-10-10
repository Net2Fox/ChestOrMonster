using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Berserk : BaseEntity
{
    private const double MaxHp = 14;

    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }

    public Berserk()
    {
        Name = "Берсерк";
        Hp = MaxHp;
        Atk = 4;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
    }

    // Особенность: ярость. Чем меньше здоровья, тем сильнее удар (до x2)
    public override DamageInfo Attack()
    {
        double lostHpPercent = Math.Clamp((MaxHp - Hp) / MaxHp, 0, 1);
        double finalAtk = Atk * (1 + lostHpPercent);
        return new DamageInfo(finalAtk, AttackType);
    }
}
