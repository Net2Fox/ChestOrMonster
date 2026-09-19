using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bow : IWeapon
{
    public string Name { get; private set; }
    public double Accuracy { get; private set; }
    private double _Damage;
    public double Damage { get {
        return new Random().NextDouble() < Accuracy ? _Damage : 0;
    } private set; }

    public Bow(string name, double damage, double accuracy)
    {
        Name = name;
        _Damage = damage;
        Accuracy = accuracy;
    }
}