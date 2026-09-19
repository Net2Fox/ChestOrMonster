using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double CritRate { get; private set; }

    public Weapon(string name, double damage, double critRate=0)
    {
        Name = name;
        Damage = damage;
        CritRate = critRate;
    }
}