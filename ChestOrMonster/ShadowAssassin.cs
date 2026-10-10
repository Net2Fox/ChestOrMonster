using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy
{
    public class ShadowAssassin : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }

        private const double CritRate = 0.4;

        private const double PassiveDodgeChance = 0.3;

        public ShadowAssassin()
        {
            Name = "Теневой убийца";
            Hp = 8;
            Atk = 9;
            Def = 2;
            AttackType = DamageType.Pure;
            Effect = StatusEffect.None;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (_random.NextDouble() < CritRate)
            {
                finalAtk *= 2.0;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
        public override DamageInfo TakeDamage(DamageInfo damage)
        {
            if (damage.Type != DamageType.Pure && _random.NextDouble() < PassiveDodgeChance)
            {
                Console.WriteLine($"{Name} Уклонился от части атаки!");
                damage = new DamageInfo(damage.Amount * 0.5, damage.Type, damage.Effect);
            }
            return base.TakeDamage(damage);
        }
    }
}
