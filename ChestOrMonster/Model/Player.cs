using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Model;

public class Player : BaseEntity
{
    public IWeapon Weapon { get; private set; } = new Weapon("Кулаки", 2);
    public IArmor Armor { get; private set; } = new Armor("Майка", 1);


    public override string Name { get; protected set; }
    public override double Hp { get; protected set; } = _maxHp;
    public override double Atk => Weapon.Damage;
    public override double Def => Armor.Def;
    public override DamageType AttackType { get;  } = DamageType.Usual;
    public override StatusEffect Effect { get; protected set; } = StatusEffect.None;
    
    private static double _maxHp = 100;
    private static double _dodgeChance = 0.4;

    public Player(string name)
    {
        Name = name;
    }
    
    public override DamageInfo Attack()
    {
        return new DamageInfo(Weapon.Damage, AttackType);
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
    
    public bool Dodge()
    {
        if (_random.NextDouble() < _dodgeChance)
        {
            return true;
        }
        return false;
    }
}