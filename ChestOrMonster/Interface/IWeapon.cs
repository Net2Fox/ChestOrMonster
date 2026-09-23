namespace ChestOrMonster.Interface;

public interface IWeapon : IBaseItem
{
    public double Damage { get; }
    public double Chance { get; }
}