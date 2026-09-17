using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bow : IWeapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Fidelity { get; private set; }

    public Bow(string name, double damage, double fidelity)
    {
        Name = name;
        Damage = damage;
        Fidelity = fidelity;
    }
}