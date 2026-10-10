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

    private static readonly (string Name, double Def)[] Armors =
    [
        ("Кожаная броня", 3),
        ("Кольчуга", 6),
        ("Латные доспехи", 10),
        ("Магический плащ", 8)
    ];

    private static readonly (string Name, double Damage, double Accuracy)[] Bows =
    [
        ("Ржавый лук", 6, 0.7),
        ("Охотничий лук", 9, 0.85),
        ("Эльфийский лук", 12, 0.95),
        ("Лук мастера", 15, 0.98),
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
        bool isBow = _random.Next(0, 2) == 0;

        if (isBow)
        {
            var template = Bows[_random.Next(0, Bows.Length)];
            return new Bow(template.Name, template.Damage, template.Accuracy);
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