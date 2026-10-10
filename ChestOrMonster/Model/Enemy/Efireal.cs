using ChestOrMonster.Interface;

namespace ChestOrMonster.Model.Enemy;
    public class Efireal : BaseEntity
    {
        public override string Name { get; }
        public override double Hp { get; protected set; }
        public override double Atk { get; }
        public override double Def { get; }
        public override DamageType AttackType { get; }
        public override StatusEffect Effect { get; protected set; }
        protected virtual double Corruption { get; }

        public Efireal()
        {
            Name = "Эфиреал";
            Hp = 40;
            Atk = 1;
            Def = -4;
            AttackType = DamageType.Usual;
            Effect = StatusEffect.None;
        }

        public override DamageInfo Attack()
        {
            StatusEffect effect = StatusEffect.None;
            if (_random.NextDouble() < 0.3)
            {
                effect = StatusEffect.Corruption;
            }
            return new DamageInfo(Atk, AttackType, effect);
        }
    }
