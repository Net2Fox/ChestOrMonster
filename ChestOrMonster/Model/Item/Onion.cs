using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Onion : Weapon
    {
        
        protected double DamageChance;
        protected static Random _random = Random.Shared;
        public Onion(string name, double damage, double DamageChance) : base (name, damage)
        {

            this.DamageChance = DamageChance;
        }
        public override double GetDamage()
        {
            if (DamageChance >= _random.NextDouble())
            { 
                return Damage;
            }
            return 0;
        }
    }
}
