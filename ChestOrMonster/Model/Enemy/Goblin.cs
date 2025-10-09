using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Goblin : IBaseEnemy
{
    public string Name { get; set; } = "Гоблин";
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