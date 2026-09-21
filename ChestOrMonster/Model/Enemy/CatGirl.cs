using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;


namespace ChestOrMonster.Model.Enemy
{
    public  class CatGirl: BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; } 
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double Shaming { get; } = 0.4;

        public CatGirl()
        {
            Name = "Кошкодевочка";
            Hp = 69;
            Atk = 34;
            Def = 13;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            Shaming = 0.4;
        }
        public override DamageInfo Attack()
        {   
            StatusEffect effect = StatusEffect.None;
            if (_random.NextDouble() <= Shaming)
            {
                effect = StatusEffect.Shamed;
            }
            return new DamageInfo(Atk, AttackType, effect);
        }

    }
}
