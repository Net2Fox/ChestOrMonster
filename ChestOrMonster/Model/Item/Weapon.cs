using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Shans { get; private set; }

    public Weapon(string name, double damage, double shans = 1.0)
    {
        Name = name;
        Damage = damage;
        Shans = shans;
    }
}