using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Mage : IBaseEnemy
{
    private static Random _random = new(DateTime.Now.Millisecond);

    public string Name { get; private set; } = "Маг";
    public double Hp { get; private set; } = 7;
    public double Atk { get; private set; } = 10;
    public double Def { get; private set; } = 1;
    
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
        throw new NotImplementedException();
    }
}