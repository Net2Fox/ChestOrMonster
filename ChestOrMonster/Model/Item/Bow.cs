using ChestOrMonster.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Bow : Weapon
    {
        public double Accuracy { get; private set; }

        public Bow(string name, double damage, double accuracy) : base(name, damage)
        {
            Accuracy = accuracy;
        }
    }
}
