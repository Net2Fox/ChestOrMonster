using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy
{
    public class Fairy : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double CritRate { get; }
        protected virtual double TripleRate { get; } = 0.3;
       

        public Fairy()
        {
            Name = "Фея";
            Hp = 10;
            Atk = 2;
           
            Def = 0;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
            CritRate = 0.8;
        }

        public override DamageInfo Attack()
        {
            StatusEffect effect = StatusEffect.None;
            double damage = Atk;
            if (_random.NextDouble() <= TripleRate)
            {
                Console.WriteLine("Усиленная атака");
                damage = Atk * 3;
            }
            return new DamageInfo(damage, AttackType, effect);
    
           }
    }
}
