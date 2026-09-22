using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class OnePunchMan : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double OneShotChance { get; }

        public OnePunchMan()
        {
            Name = "Автобус";
            Hp = 15;
            Atk = 2;
            Def = 1;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            OneShotChance = 0.02;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < OneShotChance)
            {
                finalAtk *= 100;
                Console.WriteLine("ONE SHOT!");
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}