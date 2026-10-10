using ChestOrMonster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slime : BaseEntity
{
    public override string Name { get; }
    public override double Hp { get; protected set; }
    public override double Atk { get; }
    public override double Def { get; }
    public override DamageType AttackType { get; }
    public override StatusEffect Effect { get; protected set; }
    protected virtual double DoubleDamageRate { get; }

    public Slime()
    {
        Name = "Слайм";
        Hp = 6;
        Atk = 5;
        Def = 1;
        AttackType = DamageType.Usual;
        Effect = StatusEffect.None;
        DoubleDamageRate = 0.5;
    }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        if (_random.NextDouble() < DoubleDamageRate)
        {
            finalAtk *= 2;
        }
        return new DamageInfo(finalAtk, AttackType);
    }
}