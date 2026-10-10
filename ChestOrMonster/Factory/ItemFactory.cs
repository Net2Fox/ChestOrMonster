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
        ("Длинный лук", 8),
        ("Магический посох", 15)
    ];

    private static readonly (string Name, double Damage, double Accuracy)[] Bows =
    [
        ("Длинный лук", 8, 0.6),
        ("Короткий лук", 6, 0.9),
    ];

    private static readonly (string Name, double Def)[] Armors =
    [
        ("Кожаная броня", 3),
        ("Кольчуга", 6),
        ("Латные доспехи", 10),
        ("Магический плащ", 8)
    ];
    
    public static IBaseItem CreateRandomItem()
    {
        int itemType = _random.Next(0, 3);
        return itemType switch
        {
            0 => CreateRandomWeapon(),
            1 => CreateRandomArmor(),
            2 => new HealingPotion(),
        };
    }

    private static IWeapon CreateRandomWeapon()
    {
        if (_random.NextDouble() < 0.5)
        {
            var template = Bows[_random.Next(0, Bows.Length)];
            return new Bows(template.Name, template.Damage, template.Accuracy);
        }
        else
        {
            var template = Weapons[_random.Next(0, Weapons.Length)];
            return new Weapon(template.Name, template.Damage);
        }
    }
    
    private static Armor CreateRandomArmor()
    {
        var template = Armors[_random.Next(0, Armors.Length)];
        return new Armor(template.Name, template.Def);
    }
}