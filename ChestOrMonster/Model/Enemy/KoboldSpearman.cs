using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class KoboldSpearman : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set;  }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }

        protected virtual double LowHpBonus { get; } = 1.6;
        protected virtual double RageChance { get; } = 0.25;

        public KoboldSpearman()
        {
            Name = "Кобольд-Копьеносец";
            Hp = 18;
            Atk = 5;
            Def = 2;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;

            if (Hp < 18 / 2.0)
            {
                finalAtk *= LowHpBonus;
            }

            if (_random.NextDouble() < RageChance && Effect == StatusEffect.None)
            {
                Effect = StatusEffect.Rage;
                finalAtk *= 1.2;
            }

            else if (Effect == StatusEffect.Rage)
            {
                finalAtk *= 1.2;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
