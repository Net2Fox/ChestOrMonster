using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item
{
    public class Bow : Weapon
    {
        public int Accuracy;

        public Bow(string name, int damage, int accuracy)
        : base(name, damage)
        {
            Accuracy = accuracy;
        }

        public bool Shoot()
        {
            Random random = new Random();
            return random.Next(1, 101) <= Accuracy;
        }
    }

}
