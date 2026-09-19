using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Pestov : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }

        /// <summary>Шанс пропустить атаку (0..1).</summary>
        protected virtual double SkipRate { get; } = 0.3;

        public Pestov()
        {
            Name = "Pestov";
            Hp = 12;
            Atk = 9;
            Def = 1;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
        }
        public override DamageInfo Attack()
        {
            if (_random.NextDouble() <= SkipRate)
            {
                return new DamageInfo(0, DamageType.Usual, StatusEffect.None, isMiss: true);
            }
            return new DamageInfo(Atk, AttackType, StatusEffect.None);
        }
    }
}
