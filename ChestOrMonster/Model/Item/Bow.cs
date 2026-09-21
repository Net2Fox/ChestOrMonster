using ChestOrMonster.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Bow: IWeapon
    {
        public string Name { get; private set; }
        public double Damage { get; private set; }
        public double Accuracy { get; private set; }

        public Bow(string name, double damage, double accuracy)
        {
            Name = name;
            Damage = damage;
            Accuracy = accuracy;
        }
    }
}
