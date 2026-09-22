using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Berserk : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double DoubleHitChance { get; }

        public Berserk()
        {
            Name = "Берсерк";
            Hp = 20;
            Atk = 3;
            Def = 2;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            DoubleHitChance = 0.5;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < DoubleHitChance)
            {
                finalAtk = finalAtk*2;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}