using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Bow : Weapon
    {
        private static readonly Random _random = new Random();
        public double Accuracy { get; private set; }

        public Bow (string name, double damage, double accuracy) : base(name,damage)
        {
            Accuracy = accuracy;
        }
        public bool IsHit()
        {
            if(Accuracy >= 100) return true;
            if (Accuracy <= 0) return false;
            double roll = _random.NextDouble() * 100;
            return roll <= Accuracy;
        }
    }
}
