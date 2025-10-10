using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Armor : IArmor
{
    public string Name { get; private set; }
    public double Def { get; private set; }

    public Armor(string name, double def)
    {
        Name = name;
        Def = def;
    }
}