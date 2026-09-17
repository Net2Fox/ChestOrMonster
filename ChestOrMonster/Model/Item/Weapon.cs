using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public int Percent { get; private set; }

    public Weapon(string name, double damage,int percent)
    {
        Name = name;
        Damage = damage;
        Percent = percent;
    }
}