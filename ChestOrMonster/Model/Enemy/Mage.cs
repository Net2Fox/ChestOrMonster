using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : IBaseEnemy
{
    public string Name { get; private set; } = "Маг";
    public double Hp { get; private set; } = 7;
    public double Atk { get; private set; } = 10;
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