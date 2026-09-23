using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;


namespace ChestOrMonster.Model.Enemy
{
    public class Bobr : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double BiteRate { get; }

        public Bobr()
        {
            Name = "Бобер";
            Hp = 15;
            Atk = 5;
            Def = 1;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            BiteRate = 0.75;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < BiteRate)
            {
                finalAtk += 2;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
