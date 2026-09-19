using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy
{
    public class Vodianoi : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double Tsunami { get; }

        public Vodianoi()
        {
            Name = "Водяной";
            Hp = 9;
            Atk = 4;
            Def = 2;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            Tsunami = 3;
        }

        public override DamageInfo Attack()
        {
            Random random = new Random();
            bool isTsunami = random.Next(0, 100) < 20;

            if (isTsunami)
            {
                return new DamageInfo(Tsunami * Atk, DamageType.Pure, Effect);
            }
            return new DamageInfo(Atk, DamageType.Pure, Effect);

        }
    }
}

