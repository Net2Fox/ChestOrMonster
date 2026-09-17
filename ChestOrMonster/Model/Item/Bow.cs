using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bow: IWeapon
{
    public string Name { get; }
    public double Damage { get; }
    public double Fidelity { get; }
    
    public Bow(string name, double damage, double fidelity)
    {
        Name = name;
        Damage = damage;
        Fidelity = fidelity;
    }
    
    
}