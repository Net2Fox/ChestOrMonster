using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy
{
    internal class Cat : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }

        public Cat()
        {
            Name = "Кот";
            Hp = 8;
            Atk = 7;
            Def = 1;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
        }

        public override DamageInfo Attack()
        {
            double finalAtk = Atk;
            if (Hp <= 4)
            {
                finalAtk += 10;
            }
            return new DamageInfo(finalAtk, AttackType);
        }
    }
}
