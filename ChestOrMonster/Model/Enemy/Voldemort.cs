using ChestOrMonster.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Voldemort : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double CritRate { get; }

        public Voldemort()
        {
            Name = "Lord";
            Hp = 2000;
            Atk = 20;
            Def = 50;
            AttackType = DamageType.Pure;
            Effect = StatusEffect.None;
            CritRate = 50;
        }
        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < CritRate)
            {
                finalAtk *= 3.0;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
