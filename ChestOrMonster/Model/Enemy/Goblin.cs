using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Goblin : IBaseEnemy
{
    public string Name { get; private set; } = "Гоблин";
    public double Hp { get; private set; } = 10;
    public double Atk { get; private set; } = 2;
    public double Def { get; private set; } = 3;
    
    public double Attack()
    {
        throw new NotImplementedException();
    }

    public double Defend()
    {
        throw new NotImplementedException();
    }
}