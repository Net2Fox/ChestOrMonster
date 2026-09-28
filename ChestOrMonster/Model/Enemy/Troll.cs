using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Enemy
{
    public class Troll : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double RegenRate { get; }
        protected double MaxHp { get; }

        public Troll()
        {
            Name = "Тролль";
            Hp = 15;
            MaxHp = Hp;
            Atk = 6;
            Def = 2;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            RegenRate = 0.2;
        }

        public override DamageInfo Attack()
        {
            Hp = Math.Min(MaxHp, Hp + MaxHp * RegenRate);
            return new DamageInfo(Atk, AttackType);
        }
    }
}
