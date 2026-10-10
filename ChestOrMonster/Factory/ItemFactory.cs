using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Factory;

public static class ItemFactory
{
    private static Random _random = Random.Shared;

    private static readonly (string Name, double Damage)[] Weapons =
    [
        ("Деревянный меч", 5),
        ("Стальной меч", 10),
        ("Боевой топор", 12),
        ("Магический посох", 15)
    ];

    private static readonly (string Name, double Def)[] Armors =
    [
        ("Кожаная броня", 3),
        ("Кольчуга", 6),
        ("Латные доспехи", 10),
        ("Магический плащ", 8)
    ];

    private static readonly (string Name, double Damage, double Accuracy)[] Bows =
    [
        ("Короткий лук", 6, 0.8),   
        ("Длинный лук", 8, 0.7)
    ];

    public static IBaseItem CreateRandomItem()
    {
        int itemType = _random.Next(0, 3);
        return itemType switch
        {
            0 => CreateRandomWeapon(),
            1 => CreateRandomArmor(),
            2 => new HealingPotion()
        };
    }

    private static Weapon CreateRandomWeapon()
    {
        // Лук выпадает примерно в 1 случае из 3
        if (_random.Next(0, 3) == 0)
        {
            var bow = Bows[_random.Next(0, Bows.Length)];
            return new Bow(bow.Name, bow.Damage, bow.Accuracy);
        }

        var template = Weapons[_random.Next(0, Weapons.Length)];
        return new Weapon(template.Name, template.Damage);
    }

    private static Armor CreateRandomArmor()
    {
        var template = Armors[_random.Next(0, Armors.Length)];
        return new Armor(template.Name, template.Def);
    }
}