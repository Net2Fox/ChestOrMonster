using ChestOrMonster.Model;

namespace ChestOrMonster.Interface;

public interface IBaseEntity
{
    public string Name { get; }
    public double Hp { get; }
    public DamageType  AttackType { get; }
    public StatusEffect Effect { get; }

    public DamageInfo Attack();
    public double Defend();
    
    public DamageInfo TakeDamage(DamageInfo damage);
}