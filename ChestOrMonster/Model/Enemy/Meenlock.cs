using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Meenlock : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double ScareRate { get; } = 0.35;

        public Meenlock()
        {
            Name = "Минлок";
            Hp = 6;
            Atk = 5;
            Def = 1;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            ScareRate = 0.35;
        }

        public override DamageInfo Attack()
        {
            StatusEffect effect = StatusEffect.None;
            if (_random.NextDouble() <= ScareRate)
            {
                effect = StatusEffect.Scared;
            }
            return new DamageInfo(Atk, AttackType, effect);
        }
    }
}
