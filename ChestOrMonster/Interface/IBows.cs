using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ChestOrMonster.Interface;

public interface IBows : IWeapon
{
    public double Accuracy { get; }
}
