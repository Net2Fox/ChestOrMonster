namespace ChestOrMonster.Interface;

public interface IBaseEntity
{
    public string Name { get; }
    public double Hp { get; }

    public double Attack();
    public double Defend();
}