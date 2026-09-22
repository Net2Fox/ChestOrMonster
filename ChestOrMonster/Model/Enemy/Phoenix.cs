using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;
public class Phoenix : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double BurningRate { get; } = 0.4;

    public Phoenix()
    {
        Name = "Феня";
        Hp = 10;
        Atk = 5;
        Def = 7;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
    }
    public override DamageInfo Attack()
    {

        StatusEffect effect = StatusEffect.None;
        if (_random.NextDouble() <= BurningRate)
        {
            effect = StatusEffect.Burning;
        }
        return new DamageInfo(Atk, AttackType, effect);
    }
}

