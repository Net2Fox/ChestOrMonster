using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

/// <summary>
/// Оружие дальнего боя «Лук». Имеет характеристику точности,
/// которая определяет шанс попадания при выстреле.
/// </summary>
public class Bow : IWeapon
{
    /// <summary>Название лука.</summary>
    public string Name { get; private set; }

    /// <summary>Урон, наносимый при успешном попадании.</summary>
    public double Damage { get; private set; }

    /// <summary>Шанс попадания (от 0.0 до 1.0).</summary>
    public double Accuracy { get; private set; }

    public Bow(string name, double damage, double accuracy)
    {
        Name = name;
        Damage = damage;
        Accuracy = accuracy;
    }

    /// <summary>Проверяет, попал ли выстрел.</summary>
    public bool TryHit()
    {
        return Random.Shared.NextDouble() < Accuracy;
    }
}