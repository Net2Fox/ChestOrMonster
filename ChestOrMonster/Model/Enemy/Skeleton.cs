using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : IBaseEnemy
{
    public string Name { get; set; } = "Скелет";
    public double Hp { get; set; }
    public double Atk { get; set; }
    public double Def { get; set; }
    
    public double Attack()
    {
        throw new NotImplementedException();
    }

    public double Defend()
    {
        throw new NotImplementedException();
    }
}