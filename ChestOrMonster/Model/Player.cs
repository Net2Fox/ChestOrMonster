using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Model;

public class Player : IPlayer
{
    private static Random _random = new(DateTime.Now.Millisecond);
    
    public string Name { get; private set; }
    public double Hp { get; private  set; } = _maxHp;
    public IWeapon Weapon { get; private set; } = new Weapon("Кулаки", 2);
    public IArmor Armor { get; private set; } = new Armor("Майка", 1);
    
    private static double _maxHp = 100;

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
    
    public double Attack()
    {
        return Weapon.Damage;
    }

    public double Defend()
    {
        return Armor.Def;
    }

    public double TakeDamage(double dmg)
    {
        double def = Armor.Def * (_random.Next(70, 101) / 100d);
        double finalAtk = dmg - def;
        finalAtk = finalAtk > 0 ? finalAtk : 0;
        Hp -= finalAtk;
        return finalAtk;
    }
}