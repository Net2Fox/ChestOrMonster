namespace ChestOrMonster.Interface;

public interface IBaseEnemy : IBaseEntity
{
    public double Atk { get; }
    public double Def { get; }
}