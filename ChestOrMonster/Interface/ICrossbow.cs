using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Interface
{
    public interface ICrossbow : IWeapon
    {
        public double Accuracy { get; }
    }
}
