using ChestOrMonster.Interface;

namespace ChestOrMonster.Model;

public abstract class BaseEntity
{
    protected static Random _random = Random.Shared;
    
    public abstract string Name { get; protected set; }
    public abstract double Hp { get; protected set; }
    public abstract double Atk { get; }
    public abstract double Def { get; }
    public abstract DamageType AttackType { get; }
    public abstract StatusEffect Effect { get; protected set; }
    
    public abstract DamageInfo Attack();

    public virtual DamageInfo TakeDamage(DamageInfo damage)
    {
        switch (damage.Type)
        {
            case DamageType.Usual:
                double def = Def * (_random.Next(70, 101) / 100d);
                damage = new DamageInfo(damage.Amount - def, damage.Type, damage.Effect);
                break;
        }

        Effect = damage.Effect;
        Hp -= damage.Amount;
        return damage;
    }
    
    public virtual void UpdateStatusEffect()
    {
        Effect = StatusEffect.None;
    }
}