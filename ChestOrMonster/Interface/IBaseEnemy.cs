namespace ChestOrMonster.Interface;

public interface IBaseEnemy : IBaseEntity
{
    public double Atk { get; set; }
    public double Def { get; set; }
}