namespace ChestOrMonster.Interface;

public interface IPlayer : IBaseEntity
{
    IWeapon Weapon  { get; }
    IArmor Armor { get; }

    public bool Dodge();

    public void UseItem(IBaseItem item);
}