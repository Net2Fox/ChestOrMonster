using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Model;

public class Player : IPlayer
{
    private static Random _random = Random.Shared;
    
    public string Name { get; private set; }
    public double Hp { get; private  set; } = _maxHp;
    public IWeapon Weapon { get; private set; } = new Weapon("Кулаки", 2);
    public IArmor Armor { get; private set; } = new Armor("Майка", 1);
    public DamageType AttackType { get; private set; } = DamageType.Physical;
    public StatusEffect Effect { get; private set; } = StatusEffect.None;
    
    private static double _maxHp = 100;
    private static double _dodgeChance = 0.4;

    public Player(string name)
    {
        Name = name;
    }

    public void UseItem(IBaseItem item)
    {
        switch (item)
        {
            case Armor armor:
                Armor = armor;
                break;
            case Weapon weapon:
                Weapon = weapon;
                break;
            case HealingPotion healingPotion:
                Hp = _maxHp;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(item), item, null);
        }
    }
    
    public DamageInfo Attack()
    {
        return new DamageInfo(Weapon.Damage, AttackType);
    }

    public bool Dodge()
    {
        if (_random.NextDouble() < _dodgeChance)
        {
            return true;
        }
        return false;
    }

    public DamageInfo TakeDamage(DamageInfo damage)
    {
        switch (damage.Type)
        {
            case DamageType.Physical:
                double def = Armor.Def * (_random.Next(70, 101) / 100d);
                damage.ChangeDamageAmount(damage.Amount - def);
                break;
        }
        
        Effect = damage.Effect;
        Hp -= damage.Amount;
        return damage;
    }
}