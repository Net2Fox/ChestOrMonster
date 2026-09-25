using ChestOrMonster.Interface;
using ChestOrMonster.Model;

namespace ChestOrMonster.Model.Item;

public class Bow : Weapon
{
    public double Accuracy { get; private set; }

    public Bow(string name, double damage, double accuracy)
        : base(name, damage, WeaponType.Bow)
    {
        Accuracy = accuracy;
    }
}
