using ChestOrMonster.Interface;
using System;

namespace ChestOrMonster.Model.Item;

public class Bow : IWeapon
{
    Random rand = new Random();
    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Miss { get; private set; }

    public Bow(string name, double damage)
    {
        Name = name;
        Miss = 0.5;
        if (rand.NextDouble() < Miss)
        {
            Damage = 0;
        }
        else
        {
            Damage = damage;
        }
    }
}