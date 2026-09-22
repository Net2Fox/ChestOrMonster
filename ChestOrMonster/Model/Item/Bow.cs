using System;
using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Item;

public class Bow : Weapon
{
    public int Accuracy { get; private set; }
    public Bow(string name, double damage, int accuracy) : base(name, damage)
    {
        Accuracy = accuracy;
    }

    public double Shoot()
    {
        Random random = new Random();
        int chance = random.Next(0, 101);

        if (chance <= Accuracy)
        {
            Console.WriteLine($"Выстрел из {Name} попал! Нанесено {Damage} урона.");
            return Damage;
        }
        else
        {
            Console.WriteLine($"Выстрел из {Name} промахнулся! (Шанс попадания: {Accuracy}%)");
            return 0; 
        }
    }
}