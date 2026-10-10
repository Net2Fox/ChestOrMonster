using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChestOrMonster.Interface;


namespace ChestOrMonster.Model.Item;

public class Bow : IBow
{
    private static Random _random = Random.Shared;

    public string Name { get; private set; }
    public double Damage { get; private set; }
    public double Accuracy { get; private set; }

    public Bow(string name, double damage, double accuracy)
    {
        Name = name;
        Damage = damage;
        Accuracy = accuracy;
    }

    public bool IsHit()
    {
        return _random.NextDouble() < Accuracy;
    }
}