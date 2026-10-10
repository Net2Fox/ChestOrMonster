using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bows : IBows
{
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Accuracy { get; private set; }

    public Bows(string name, double damage, double accuracy)
    {
        Name = name;
        Damage = damage;
        Accuracy = accuracy;
    }
}