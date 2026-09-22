using ChestOrMonster.Interface;


namespace ChestOrMonster.Model.Item
{
    internal class Bow : Weapon, IWeapon
    {
        private static readonly Random _random = new Random();
      
        public int Accuracy { get; }

        public Bow(string name, double damage, int accuracy): base(name, damage)
        {
            Accuracy = Math.Clamp(accuracy, 0, 100);
        }
        public bool IsHit()
        {
            return _random.Next(0, 100) < Accuracy;
        }
    }
}