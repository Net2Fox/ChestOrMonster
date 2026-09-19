using ChestOrMonster.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Luk : IWeapon
    {
        private static readonly Random _random = new Random();
        public string Name { get; set; }

        public double Damage { get; set; }
        public int Accuracy { get; } 

        public Luk(string name, double damage, int accuracy) 
        {
            Name = name;
            Damage = damage;
            Accuracy = Math.Clamp(accuracy, 0, 100);
        }
        public bool IsHit()
        {
            return _random.Next(0, 100) < Accuracy;
        }
    }
}
