using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestOrMonster.Model.Item;

public class Bow : Weapon
{
    private static readonly Random _random = Random.Shared;

    // Точность: шанс попадания от 0 до 1
    public double Accuracy { get; private set; }

    public Bow(string name, double damage, double accuracy) : base(name, damage)
    {
        Accuracy = accuracy;
    }

    // true - стрела попала, false - промах
    public bool IsHit()
    {
        return _random.NextDouble() < Accuracy;
    }
}