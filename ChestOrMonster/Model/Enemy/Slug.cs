using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Slug : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected double RateUdarPoSebe { get; }

        public Slug()
        {
            Name = "Скелет";
            Hp = 5;
            Atk = 7;
            Def = 1;
            AttackType = DamageType.Pure;
            Effect = StatusEffect.None;
            RateUdarPoSebe = .4;
        }
        public override DamageInfo Attack()
        {
            double atk = Atk;
            if (_random.NextDouble() < RateUdarPoSebe)
            {
                Hp -= atk;
                atk = 0;
            }
            return new DamageInfo(Atk, AttackType);
        }
    }
}
