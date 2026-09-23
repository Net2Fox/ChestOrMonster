using ChestOrMonster.Model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy.Boss
{
    public class Lich : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double VampireRate { get; } = 0.8;

        public Lich()
        {
            Name = "Лич";
            Hp = 35;
            Atk = 9;
            Def = 6;
            AttackType = DamageType.Pure;
            Effect = StatusEffect.None;
            VampireRate = 0.8;
        }

        public override DamageInfo Attack()
        {
            StatusEffect effect = StatusEffect.None;
            if (_random.NextDouble() <= VampireRate)
            {
                effect = StatusEffect.Sucked;
                Healing(Atk);
            }
            return new DamageInfo(Atk, AttackType, effect);
        }

        public void Healing (double atk)
        {
            if(Hp + atk > 35)
            {
                Hp = 35;
            }
            else
            {
                Hp = Hp + atk;
            }
        }
       
    }
}
