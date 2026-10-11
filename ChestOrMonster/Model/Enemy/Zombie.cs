using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Zombie : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double CritRate { get; }

        public Zombie()
        {
            Name = "Зомбяка";
            Hp = 20;
            Atk = 2;
            Def = 2;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.Poisoned;
            CritRate = 0.1;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;

            if (_random.NextDouble() < CritRate) 
            {
                finalAtk *= 2;
            }

            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
