using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Skeleton : IBaseEnemy
{
    public string Name { get; private set; } = "Скелет";
    public double Hp { get; private set; }
    public double Atk { get; private set; }
    public double Def { get; private set; }
    
    public double Attack()
    {
        throw new NotImplementedException();
    }

    public double Defend()
    {
        throw new NotImplementedException();
    }
}