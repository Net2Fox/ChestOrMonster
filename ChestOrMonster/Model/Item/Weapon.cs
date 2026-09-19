using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Weapon : IWeapon
{
    public virtual string Name { get; private set; }
    public virtual double Damage { get; private set; }

    public Weapon(string name, double damage)
    {
        Name = name;
        Damage = damage;
    }
    public virtual double GetDamage()
    {
        return Damage;
    }
}