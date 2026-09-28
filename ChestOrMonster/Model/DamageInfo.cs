namespace ChestOrMonster.Model;

public struct DamageInfo
{
    public double Amount { get; private set; }
    public DamageType Type { get; private set; }
    public StatusEffect Effect { get; private set; }
    public bool IsMiss {  get; private set; }

    public DamageInfo(double amount, DamageType type = DamageType.Usual, StatusEffect effect = StatusEffect.None, bool isMiss = false)
    {
        Amount = Math.Max(0, amount);
        Type = type;
        Effect = effect;
        IsMiss = isMiss;
    }
}