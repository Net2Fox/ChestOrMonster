namespace ChestOrMonster.Interface;

public interface IBaseEntity
{
    public string Name { get; set; }
    public double Hp { get; set; }

    public double Attack();
    public double Defend();
}