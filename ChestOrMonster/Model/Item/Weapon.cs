using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public string Name { get; set; }
    public double Damage { get; set; }

    public Weapon(string name, double damage)
    {
        Name = name;
        Damage = damage;
    }
}