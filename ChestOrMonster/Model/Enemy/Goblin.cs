using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Goblin : IBaseEnemy
{
    private static Random _random = new(DateTime.Now.Millisecond);

    public string Name { get; private set; } = "Гоблин";
    public double Hp { get; private set; } = 10;
    public double Atk { get; private set; } = 2;
    public double Def { get; private set; } = 3;
    
    public double Attack()
    {
        return Atk;
    }

    public double Defend()
    {
        return Def;
    }

    public double TakeDamage(double dmg)
    {
        double def = Def * (_random.Next(70, 101) / 100d);
        double finalAtk = dmg - def;
        finalAtk = finalAtk > 0 ? finalAtk : 0;
        Hp -= finalAtk;
        return finalAtk;
    }
}