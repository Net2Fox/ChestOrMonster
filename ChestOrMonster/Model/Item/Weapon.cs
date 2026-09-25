using ChestOrMonster.Interface;
using ChestOrMonster.Model;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public WeaponType Type { get; protected set; }

    public Weapon(string name, double damage, WeaponType type = WeaponType.Melee)
    {
        Name = name;
        Damage = damage;
        Type = type;
    }
}
