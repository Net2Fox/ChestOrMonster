namespace ChestOrMonster.Interface;

public interface IWeapon : IBaseItem
{
    public double Damage { get; }
    public virtual double GetDamage()
    {
        return Damage;
    }
}