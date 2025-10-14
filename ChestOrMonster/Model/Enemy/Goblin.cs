using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;

public class Goblin : IBaseEnemy
{
    private static Random _random = new(DateTime.Now.Millisecond);

    public string Name { get; private set; } = "Гоблин";
    public double Hp { get; private set; } = 10;
    public double Atk { get; private set; } = 2;
    public double Def { get; private set; } = 3;
    public DamageType AttackType { get; private set; } = DamageType.Physical;
    public StatusEffect Effect { get; private set; } = StatusEffect.None;
    private double CritRate { get; set; } = 0.3;

    public DamageInfo Attack()
    {
        
        double finalAtk = Atk;
        if (_random.NextDouble() <= CritRate)
        {
            finalAtk *= 1.5;
        }
        return new DamageInfo(finalAtk, AttackType);
    }

    public double Defend()
    {
        return Def;
    }

    public DamageInfo TakeDamage(DamageInfo damage)
    {
        switch (damage.Type)
        {
            case DamageType.Physical:
                double def = Def * (_random.Next(70, 101) / 100d);
                damage.ChangeDamageAmount(damage.Amount - def);
                break;
        }

        Effect = damage.Effect;
        Hp -= damage.Amount;
        return damage;
    }
}