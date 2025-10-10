using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class HealingPotion : IBaseItem
{
    public string Name { get; private set; } = "Лечебное зелье";
}