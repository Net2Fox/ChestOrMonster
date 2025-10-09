using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : IBaseEnemy
{
    public string Name { get; set; } = "Маг";
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