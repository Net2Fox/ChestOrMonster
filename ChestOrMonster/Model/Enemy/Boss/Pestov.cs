using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy;

    internal class Pestov : BaseEntity
    {
        public override string  Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected double CritRate { get; }
        protected double FlameRate { get; }

        public Pestov()
        {
            Name = "Пестов ууу";
            Hp = 100;
            Atk = 10;
            Def = 0;
            AttackType = DamageType.Pure;
            Effect = StatusEffect.Flame;
            CritRate = 0.8;
            FlameRate = 0.67;
        }

    public override DamageInfo Attack()
    {
        double finalAtk = Atk;
        if (_random.NextDouble() < CritRate)
        {
            finalAtk *= 1.5;
        }
        if (_random.NextDouble() < FlameRate)
        {
            finalAtk *= 1.67;
        }
        return new DamageInfo(finalAtk, AttackType);
    }
}

