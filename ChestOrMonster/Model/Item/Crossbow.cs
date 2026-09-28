using ChestOrMonster.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Crossbow : ICrossbow
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public double Accuracy { get; set; }


        public Crossbow(string name, double damage, double accuracy)
        {
            Name = name;
            Damage = damage;
            Accuracy = accuracy;
        }
    }
}
