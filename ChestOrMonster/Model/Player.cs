using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Model;

public class Player : IPlayer
{
    public string Name { get; set; }
    public double Hp { get; set; } = _maxHp;
    public IBaseItem? Weapon { get; set; } = null;
    public IBaseItem? Armor { get; set; } = null;
    
    private static double _maxHp = 100;

    public Player(string name)
    {
        Name = name;
    }

    public void ChangeEquipment(IBaseItem item)
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
        throw new NotImplementedException();
    }

    public double Defend()
    {
        throw new NotImplementedException();
    }
}