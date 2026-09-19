using ChestOrMonster.Interface;
using ChestOrMonster.Model.Item;

namespace ChestOrMonster.Factory;

public static class ItemFactory
{
    private static Random _random = Random.Shared;

    private static readonly (string Name, double Damage)[] GenericWeapons =
    [
        ("Деревянный меч", 5),
        ("Стальной меч", 10),
        ("Боевой топор", 12),
        ("Длинный лук", 8),
        ("Магический посох", 15)
    ];
    private static readonly (string Name, double Damage, double Accuracy)[] Bows =
    [
        ("Недлинный лук", 8, 0.8)
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
            2 => new HealingPotion()
        };
    }

    private static IWeapon CreateRandomWeapon()
    {
        var nr = _random.Next(0, GenericWeapons.Length + Bows.Length);
        if (nr < GenericWeapons.Length)
        {
            var weapon = GenericWeapons[nr];
            return new Weapon(weapon.Name, weapon.Damage);
        }
        else {
            var weapon = Bows[nr - GenericWeapons.Length];
            return new Bow(weapon.Name, weapon.Damage, weapon.Accuracy);
        }
    }
    
    private static IArmor CreateRandomArmor()
    {
        var template = Armors[_random.Next(0, Armors.Length)];
        return new Armor(template.Name, template.Def);
    }
}