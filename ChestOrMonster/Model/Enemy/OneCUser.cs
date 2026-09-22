using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class OneCUser : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double CritRate { get; }

        public OneCUser()
        {
            Name = "1С юзер";
            Hp = 100;
            Atk = 6;
            Def = 7;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            CritRate = 0.67;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < CritRate)
            {
                finalAtk *= 1.1;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
