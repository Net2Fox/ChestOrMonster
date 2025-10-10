using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : IBaseEnemy
{
    public string Name { get; private set; } = "Скелет";
    public double Hp { get; private set; } = 5;
    public double Atk { get; private set; } = 7;
    public double Def { get; private set; } = 1;
    
    public double Attack()
    {
        throw new NotImplementedException();
    }

    public double Defend()
    {
        throw new NotImplementedException();
    }
}