namespace ChestOrMonster.Model.Item;

public class Bow : Weapon
{
    // Шанс попадания при выстреле: от 0 до 1
    public double Accuracy { get; private set; }

    public Bow(string name, double damage, double accuracy) : base(name, damage)
    {
        Accuracy = accuracy;
    }
}
