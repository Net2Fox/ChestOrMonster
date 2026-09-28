using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;
using System.Globalization;

namespace ChestOrMonster.Factory;

public static class ItemFactory
{
    private static Random _random = Random.Shared;

    private static readonly (string Name, double Damage)[] Weapons =
    [
        ("Деревянный меч", 5),
        ("Стальной меч", 10),
        ("Боевой топор", 12),
        ("Длинный лук", 8),
        ("Магический посох", 15)
    ];

    private static readonly (string Name, double Def)[] Armors =
    [
        ("Кожаная броня", 3),
        ("Кольчуга", 6),
        ("Латные доспехи", 10),
        ("Магический плащ", 8)
    ];

    private static readonly (string Name, double Damage, double Accuracy)[] Crossbows =
    [
        ("Лёгкий арбалет", 7, 0.8),
        ("Тяжёлый арбалет", 14, 0.55),
        ("Арбалет-разведчик", 10, 0.7)
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

    private static IWeapon CreateRandomWeapon()
    {
        bool isCrossbow = _random.Next(0, 2) == 0;
        if (isCrossbow)
        {
            var crossbowTemplate = Crossbows[_random.Next(0, Crossbows.Length)];
            return new Crossbow(crossbowTemplate.Name, crossbowTemplate.Damage, crossbowTemplate.Accuracy);
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