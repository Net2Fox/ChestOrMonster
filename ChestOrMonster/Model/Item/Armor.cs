using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Armor : IArmor
{
    public string Name { get; set; }
    public double Def { get; set; }

    public Armor(string name, double def)
    {
        Name = name;
        Def = def;
    }
}