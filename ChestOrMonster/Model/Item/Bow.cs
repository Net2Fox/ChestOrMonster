using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bow : IWeapon
{
    public string Name { get; }
    public double Damage { get; }
    public double Accuracy { get; }

    public Bow(string name, double damage, double accuracy)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название лука не может быть пустым.", nameof(name));
        }
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage));
        }
        if (accuracy is < 0 or > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(accuracy));
        }

        Name = name;
        Damage = damage;
        Accuracy = accuracy;
    }

    public DamageInfo Attack(double accuracyRoll, DamageType damageType = DamageType.Usual)
    {
        if (accuracyRoll is < 0 or > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(accuracyRoll));
        }

        double finalDamage = accuracyRoll < Accuracy ? Damage : 0;
        return new DamageInfo(finalDamage, damageType);
    }
}
