using ChestOrMonster.Interface;
using ChestOrMonster.Model;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Factory;

public static class ItemFactory
{
    private static Random _random = Random.Shared;

    private static readonly (string Name, double Damage)[] MeleeWeapons =
    [
        ("Деревянный меч", 5),
        ("Стальной меч", 10),
        ("Боевой топор", 12),
        ("Магический посох", 15)
    ];

    private static readonly (string Name, double Damage, double Accuracy)[] Bows =
    [
        ("Длинный лук", 8, 0.75),
        ("Лесной лук", 10, 0.8),
        ("Серебряный лук", 12, 0.85)
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
            _ => throw new InvalidOperationException("Неизвестный тип предмета.")
        };
    }

    private static Weapon CreateRandomWeapon()
    {
        if (_random.NextDouble() < 0.5)
        {
            var template = MeleeWeapons[_random.Next(0, MeleeWeapons.Length)];
            return new Weapon(template.Name, template.Damage, WeaponType.Melee);
        }

        var bowTemplate = Bows[_random.Next(0, Bows.Length)];
        return new Bow(bowTemplate.Name, bowTemplate.Damage, bowTemplate.Accuracy);
    }

    private static Armor CreateRandomArmor()
    {
        var template = Armors[_random.Next(0, Armors.Length)];
        return new Armor(template.Name, template.Def);
    }
}
