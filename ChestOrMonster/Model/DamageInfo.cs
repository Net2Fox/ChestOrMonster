namespace ChestOrMonster.Model;

public struct DamageInfo
{
    public double Amount { get; private set; }
    public DamageType Type { get; private set; }
    public StatusEffect Effect { get; private set; }

    public DamageInfo(double amount, DamageType type = DamageType.Physical, StatusEffect effect = StatusEffect.None)
    {
        Amount = amount;
        Type = type;
        Effect = effect;
    }
    
    public void ChangeDamageAmount(double amount)
    {
        switch (amount)
        {
            case < 0:
                Amount = 0;
                break;
            default:
                Amount = amount;
                break;
        }
    }
}